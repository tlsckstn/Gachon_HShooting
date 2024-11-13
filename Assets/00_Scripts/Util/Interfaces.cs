using UnityEngine;

public interface IMoveable
{
    public void Move(Vector3 vec, float speed);
}

public interface IDamageable<TDamageStat> where TDamageStat : Stat
{
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