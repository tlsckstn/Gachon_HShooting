using UnityEngine;

public class EnemyType5Shooter : EnemyShooter
{
    [SerializeField] private float startValue = -1f;
    [SerializeField] private float increaseAmount = 0.25f;

    public override void Shoot(Vector3 dir)
    {
        base.Shoot(dir);
        dir = Vector3.left;
        for (float i = startValue; i <= -startValue; i += increaseAmount)
        {
            ProjectileController projectile = ObjectPool.Instance.GetObject<ProjectileController>(proejectilePool.PoolName, ShootTfs[0].position);
            projectile.Init(damage);
            projectile.Movement.Move(dir + (Vector3.up * i));

            projectiles.Add(projectile);
        }
    }
}
