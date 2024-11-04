using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat : ICloneable
{
    #region Events
    public delegate void StatChangeHandler();
    public event StatChangeHandler OnVaueChanged;
    #endregion

    [SerializeField] private float baseValue;

    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            baseValue = value;
            CalculateModifierValue();
            OnVaueChanged?.Invoke();
        }
    }

    private float currentValue;

    public float Value
    {
        get
        {
            if(isDirty)
            {
                currentValue = CalculateModifierValue();
                OnVaueChanged?.Invoke();
            }

            return currentValue;
        }
    }

    private Dictionary<ModifierType, List<Modifier>> modifierDict = new();
    private bool isDirty = false;

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
    }

    public void Setup()
    {
        modifierDict = new();
        modifierDict.Add(ModifierType.Additive, new List<Modifier>());
        modifierDict.Add(ModifierType.Multiplicative, new List<Modifier>());
    }

    public object Clone()
    {
        return new Stat(baseValue);
    }

    public void AddModifier(Modifier modifier)
    {
        if(HasModfier(modifier))
        {
            Debug.Log("이미 존재하는 Modifier입니다. " +  modifier.Name);
            return;
        }

        isDirty = true;
        modifierDict[modifier.Type].Add(modifier);
    }

    public void AddModifiers(IReadOnlyList<Modifier> modifiers)
    {
        for (int i = 0; i < modifiers.Count; i++)
        {
            AddModifier(modifiers[i]);
        }
    }

    public void RemoveModifier(Modifier modifier)
    {
        if (!HasModfier(modifier))
        {
            Debug.Log("존재하지 않는 Modifier입니다. " + modifier.Name);
            return;
        }

        isDirty = true;
        modifierDict[modifier.Type].Remove(modifier);
    }

    public void RemoveModifiers(IReadOnlyList<Modifier> modifiers)
    {
        for (int i = 0; i < modifiers.Count; i++)
        {
            RemoveModifier(modifiers[i]);
        }
    }

    private float CalculateModifierValue()
    {
        float finalValue = baseValue;

        foreach (var item in modifierDict)
        {
            for (int i = 0; i < item.Value.Count; i++)
            {
                finalValue += item.Value[i].CalculateModifier(baseValue);
            }
        }

        isDirty = false;
        return finalValue;
    }

    private bool HasModfier(Modifier modifier) => modifierDict[modifier.Type].Contains(modifier);
}