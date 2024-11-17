using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] protected float shootDelay;
    [SerializeField] protected Pool proejectilePool;
    
    protected float damage;

    public float ShootDelay => shootDelay;
    public float Damage => damage;

    public virtual void Init(float damage)
    {
        this.damage = damage;
    }

    public abstract void Shoot(Vector3 vec);
}
