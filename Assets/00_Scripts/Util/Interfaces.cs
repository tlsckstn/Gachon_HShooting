using UnityEngine;

public interface IMoveable
{

}

public interface IDamageable<TStatSO, TDamageStat>
    where TStatSO : StatSO
    where TDamageStat : Stat
{
    TStatSO StatData { get; }
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