using UnityEngine;

public class PlayerShooter : MonoBehaviour, IShootable
{
    [field: SerializeField] public float ShootDelay { get; set; } = 0.2f;
    [SerializeField] private Pool proejectilePool;

    public void Init()
    {
        ObjectPool.Instance.RegisterPool(proejectilePool);
        InputManager.Instance.SetShootDelay(ShootDelay);
    }

    public void Shoot()
    {
        ObjectPool.Instance.GetObject(proejectilePool.PoolName, transform.position);
    }
}