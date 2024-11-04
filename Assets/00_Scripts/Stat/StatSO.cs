using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "Scriptable Objects/StatSO")]
public class StatSO : ScriptableObject, ICloneable
{
    [SerializeField] private Stat hpStat;
    [SerializeField] private Stat damageStat;
    [SerializeField] private Stat speedStat;

    public object Clone()
    {
        hpStat = hpStat.Clone() as Stat;
        damageStat = damageStat.Clone() as Stat;
        speedStat = speedStat.Clone() as Stat;

        return Instantiate(this);
    }
}
