using System;
using UnityEngine;

/// <summary>
/// �������� �Ͻ����� ����, Ȥ�� ���������� ��� ���ݷ� ���� � ��� ����
/// HP ȸ���� ��� Modifier�� ������� �ʰ� BaseValue�� ����
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