using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat : ICloneable
{
    #region Events
    public delegate void StatValueChangeHandler();
    public event StatValueChangeHandler OnVaueChanged;
    #endregion

    [SerializeField] private float baseValue;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    [Space]
    [SerializeField] private bool isPercentType = false;

    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            baseValue = value;
            currentValue = Mathf.Clamp(CalculateModifierValue(), minValue, maxValue);
            OnVaueChanged?.Invoke();
        }
    }

    public float MinValue => minValue;
    public float MaxValue => maxValue;
    public bool IsPercentType => isPercentType;

    private float currentValue;

    public float Value
    {
        get
        {
            if(isDirty)
            {
                currentValue = Mathf.Clamp(CalculateModifierValue(), minValue, maxValue);
                OnVaueChanged?.Invoke();
            }

            return currentValue;
        }
    }

    private Dictionary<ModifierType, List<Modifier>> modifierDict = new();
    private bool isDirty = false;

    public Stat(Stat stat)
    {
        this.baseValue = stat.BaseValue;
        this.minValue = stat.MinValue;
        this.maxValue = stat.MaxValue;
        this.isPercentType = stat.IsPercentType;
    }

    public void Setup()
    {
        modifierDict = new();
        modifierDict.Add(ModifierType.Additive, new List<Modifier>());
        modifierDict.Add(ModifierType.Multiplicative, new List<Modifier>());
    }

    public object Clone()
    {
        return new Stat(this);
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