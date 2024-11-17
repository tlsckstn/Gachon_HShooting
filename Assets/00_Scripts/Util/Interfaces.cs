using UnityEngine;

public interface IMoveable
{
    public void Move(Vector3 vec);
    public void SetSpeed(float speed);
}

public interface IDamageable
{
    public void TakeDamage(float damage);
    public void Die();
}

public interface IName
{
    public string Name { get; set; }
}

public interface IShootable
{
    public void Init(float damage);
    public void Shoot(Vector3 vec);
}

public interface IRotateable
{
    public void Rotate(Vector3 vec);
}