using UnityEngine;

public abstract class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] protected float shootDelay;
    [SerializeField] protected Pool proejectilePool;

    public float ShootDelay => shootDelay;

    public abstract void Init();

    public abstract void Shoot(Vector3 vec);
}
