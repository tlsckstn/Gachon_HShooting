using UnityEngine;

public interface IMoveable
{
    public void Move(Vector3 vec);
    public void SetSpeed(float speed);
}

public interface IDamageable<TDamageStat> where TDamageStat : Stat
{
    public void TakeDamage(TDamageStat attacker);
}

public interface IName
{
    public string Name { get; set; }
}

public interface IShootable
{
    public void Init();
    public void Shoot();
}