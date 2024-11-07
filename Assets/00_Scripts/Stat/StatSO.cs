using System;
using UnityEngine;

/// <summary>
/// Stat들을 가지고 있는 ScriptableObject
/// 함수 호출 순서: Clone 함수로 복사 후 Init 함수로 세팅
/// </summary>
[CreateAssetMenu(fileName = "StatSO", menuName = "Scriptable Objects/StatSO")]
public class StatSO : ScriptableObject, ICloneable
{
    #region Events
    public delegate void StatChangeHandler(Stat stat);
    public event StatChangeHandler OnHPStatChanged;
    public event StatChangeHandler OnDamageStatChanged;
    public event StatChangeHandler OnSpeedStatChanged;
    #endregion

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

    public void Init()
    {
        hpStat.OnVaueChanged += () => OnHPStatChanged?.Invoke(hpStat);
        damageStat.OnVaueChanged += () => OnDamageStatChanged?.Invoke(damageStat);
        speedStat.OnVaueChanged += () => OnSpeedStatChanged?.Invoke(speedStat);
    }

    public void TakeDamage(Stat attacker)
    {
        hpStat.BaseValue -= attacker.Value;
    }
}
