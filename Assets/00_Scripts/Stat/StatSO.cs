using System;
using UnityEngine;

/// <summary>
/// Stat���� ������ �ִ� ScriptableObject
/// �Լ� ȣ�� ����: Clone �Լ��� ���� �� Init �Լ��� ����
/// </summary>
[CreateAssetMenu(fileName = "StatSO", menuName = "Scriptable Objects/StatSO")]
public class StatSO : ScriptableObject, ICloneable
{
    [SerializeField] private Stat hpStat;
    [SerializeField] private Stat damageStat;
    [SerializeField] private Stat speedStat;

    public Stat HPStat => hpStat;
    public Stat DamageStat => damageStat;
    public Stat SpeedStat => speedStat;

    public object Clone() => Instantiate(this);

    public void Init()
    {
        hpStat.Setup();
        damageStat.Setup();
        speedStat.Setup();
    }

    public void TakeDamage(Stat attacker)
    {
        TakeDamage(attacker.Value);
    }

    public void TakeDamage(float damage)
    {
        hpStat.BaseValue -= damage;
    }

    public float GetHp()
    {
        return hpStat.Value;
    }
}
