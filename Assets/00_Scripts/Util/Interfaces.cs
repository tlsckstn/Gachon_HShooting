using UnityEngine;

public interface IMoveable
{

}

public interface IDamageable<THPStat, TDamageStat>
    where THPStat : Stat
    where TDamageStat : Stat
{
    public void TakeDamage(THPStat defencer, TDamageStat attacker);
}

public interface IName
{
    public string Name { get; set; }
}

public interface IDescription
{
    public string Description { get; set; }
}