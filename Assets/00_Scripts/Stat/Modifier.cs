using System;
using UnityEngine;

/// <summary>
/// 버프같은 일시적인 증가, 혹은 아이템으로 얻는 공격력 증가 등에 사용 예정
/// HP 회복의 경우 Modifier를 사용하지 않고 BaseValue를 변경
/// </summary>
[System.Serializable]
public class Modifier : IEquatable<Modifier>
{
    [SerializeField] private float value;
    [SerializeField] private ModifierType type;

    public float Value => value;
    public ModifierType Type => type;

    public float CalculateModifier(float baseValue)
    {
        return type == ModifierType.Additive ? value : baseValue * value;
    }

    public bool Equals(Modifier other) =>
        type == other.type &&
        Mathf.Approximately(value, other.value);
}