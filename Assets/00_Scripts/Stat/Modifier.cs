using System;
using UnityEngine;

[System.Serializable]
public class Modifier : IEquatable<Modifier>, IName
{
    [SerializeField] private float value;
    [SerializeField] private ModifierType type;

    [field: SerializeField] public string Name { get; set; }

    public float Value => value;
    public ModifierType Type => type;

    public float CalculateModifier(float baseValue)
    {
        return type == ModifierType.Additive ? value : baseValue * value;
    }

    public bool Equals(Modifier other) =>
        type == other.type &&
        Mathf.Approximately(value, other.value) &&
        Name == other.Name;
}