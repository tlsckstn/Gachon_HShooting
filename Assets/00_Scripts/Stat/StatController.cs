using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour, IDamageable
{
    #region
    public delegate void UnitDieHandler();
    public event UnitDieHandler OnUnitDied;
    #endregion

    [SerializeField] private StatSO statData;

    public StatSO Stats { get; private set; }

    public float GetHPValue() => Stats.HPStat.Value;
    public float GetDamageValue() => Stats.DamageStat.Value;
    public float GetSpeedValue() => Stats.SpeedStat.Value;

    public void TakeDamage(float damage)
    {
        Stats.TakeDamage(damage);
        Debug.Log(Stats.HPStat.BaseValue);
        Debug.Log(Stats.HPStat.MinValue);
        Debug.Log(Stats.HPStat.IsMinValue());
        if(Stats.HPStat.IsMinValue())
        {
            Die();
        }
    }

    public void Init()
    {
        if(statData == null)
        {
            Debug.LogError("Don't have StatData: " + gameObject.name);
            return;
        }

        Stats = statData.Clone() as StatSO;
        Stats.Init();
    }

    public void AddModifier(Modifier modifier)
    {
        Stats.HPStat.AddModifier(modifier);
    }

    public void AddModifiers(IReadOnlyList<Modifier> modifiers)
    {
        for (int i = 0; i < modifiers.Count; i++)
        {
            AddModifier(modifiers[i]);
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