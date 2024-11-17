using UnityEngine;

public class EnemyType5Shooter : EnemyShooter
{
    public override void Shoot(Vector3 dir)
    {
        base.Shoot(dir);
        dir = Vector3.left;
        for (float i = -1; i <= 1; i += 0.25f)
        {
            ProjectileController projectile = ObjectPool.Instance.GetObject<ProjectileController>(proejectilePool.PoolName, ShootTfs[0].position);
            projectile.Init(this);
            projectile.Movement.Move(dir + (Vector3.up * i));

            projectiles.Add(projectile);
        }
    }
}
