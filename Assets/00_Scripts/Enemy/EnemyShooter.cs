using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MultiShooter
{
    protected List<ProjectileController> projectiles = new();

    public void SetShootTfs(IReadOnlyList<Transform> shootTfs)
    {
        ShootTfs = shootTfs;
    }

    public override void Shoot(Vector3 dir)
    {
        for (int i = 0; i < ShootTfs.Count; i++)
        {
            ProjectileController projectile = ObjectPool.Instance.GetObject<ProjectileController>(proejectilePool.PoolName, ShootTfs[i].position);
            projectile.Init(this);
            projectile.Movement.Move(dir);

            projectiles.Add(projectile);
        }
    }

    public void MoveProjectiles()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].Movement.Move((Utilities.GetPlayerPos()));
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].ReturnPool();
        }
    }
}
