using UnityEngine;

public class PlayerShooter : SoloShooter
{
    public override void Init(float damage)
    {
        base.Init(damage);

        ObjectPool.Instance.RegisterPool(proejectilePool);
        InputManager.Instance.SetShootDelay(shootDelay);
    }

    public override void Shoot(Vector3 dir)
    {
        ProjectileController projectile = ObjectPool.Instance.GetObject<ProjectileController>(proejectilePool.PoolName, shootTf.position);
        projectile.Init(this);
        projectile.Movement.Move(dir);
    }
}