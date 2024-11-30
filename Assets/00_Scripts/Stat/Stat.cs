using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// HP, Damage, Speed 스탯들
/// baseValue와 Value를 나눈 이유는 버프(Modifier)가 더해질때 곱하기 연산이 들어가면 값이 비정상적으로 커지기 때문
/// 따라서 baseValue는 기본값, Value는 버프를 합친 최종 값
/// </summary>
[System.Serializable]
public class Stat
{
    #region Events
    public delegate void StatValueChangeHandler();
    public event StatValueChangeHandler OnVaueChanged;
    #endregion

    [SerializeField] private float baseValue;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            baseValue = value;
            baseValue = Mathf.Clamp(baseValue, minValue, maxValue);
            currentValue = Mathf.Clamp(CalculateModifierValue(), minValue, maxValue);
            OnVaueChanged?.Invoke();
        }
    }

    public float MinValue => minValue;
    public float MaxValue => maxValue;

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
    private bool isDirty = true;

    public void Setup()
    {
        modifierDict = new()
        {
            { ModifierType.Additive, new List<Modifier>() },
            { ModifierType.Multiplicative, new List<Modifier>() }
        };
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

    public void RemoveAllModifiers()
    {
        modifierDict = new()
        {
            { ModifierType.Additive, new List<Modifier>() },
            { ModifierType.Multiplicative, new List<Modifier>() }
        };

        isDirty = true;
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

    public bool HasModfier(Modifier modifier) => modifierDict[modifier.Type].Contains(modifier);
    public bool IsMinValue() => Mathf.Approximately(baseValue, minValue);
    public bool IsMaxValue() => Mathf.Approximately(baseValue, maxValue);
}