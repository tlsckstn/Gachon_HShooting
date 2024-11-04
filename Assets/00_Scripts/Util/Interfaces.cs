using UnityEngine;

public interface IMoveable
{

}

public interface IDamageable<THPStat, TDamageStat>
    where THPStat : StatSO
    where TDamageStat : Stat
{
    THPStat Stat { get; }
    public void TakeDamage(TDamageStat attacker);
}

public interface IName
{
    public string Name { get; set; }
}

public interface IDescription
{
    public string Description { get; set; }
}