using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유닛(플레이어, 적)들의 스탯을 관리
/// 데미지를 받고 스탯들을 리턴하는 것이 역할
/// </summary>
public class StatController : MonoBehaviour, IDamageable
{
    #region
    public delegate void UnitDieHandler();
    public event UnitDieHandler OnUnitDied;
    #endregion

    [SerializeField] private StatSO statData;

    public StatSO Stats { get; private set; }

    private float baseHp;

    public float GetBaseHPValue() => Stats.HPStat.BaseValue;
    public float GetDamageValue() => Stats.DamageStat.Value;
    public float GetSpeedValue() => Stats.SpeedStat.Value;

    public void Init()
    {
        if(statData == null)
        {
            Debug.LogError("Don't have StatData: " + gameObject.name);
            return;
        }

        Stats = statData.Clone() as StatSO;
        Stats.Init();
        baseHp = GetBaseHPValue();
    }

    public void TryIncreaseStat(float hpAmount, Modifier modifier)
    {
        if (Stats.DamageStat.HasModfier(modifier))
            return;

        Stats.DamageStat.AddModifier(modifier);
        Stats.HPStat.BaseValue += hpAmount;
    }

    public void ReturnAllIncrease()
    {
        Stats.HPStat.BaseValue = baseHp;
        Stats.DamageStat.RemoveAllModifiers();
    }

    public void TakeDamage(float damage)
    {
        Stats.TakeDamage(damage);
        if (Stats.HPStat.IsMinValue())
        {
            Die();
        }
    }

    public void Die()
    {
        OnUnitDied?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(Stats.DamageStat.Value);
        }
    }
}