using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] protected Pool proejectilePool;

    public override void Init()
    {
        ObjectPool.Instance.RegisterPool(proejectilePool);
        InputManager.Instance.SetShootDelay(shootDelay);
    }

    public override void Shoot()
    {
        ObjectPool.Instance.GetObject(proejectilePool.PoolName, shootTf.position);
    }
}