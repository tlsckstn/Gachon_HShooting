using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    private List<IMoveable> projectiles = new();

    public override void Init()
    {
        
    }

    public override void Shoot()
    {
        IMoveable movement = ObjectPool.Instance.GetObject<IMoveable>(proejectilePool.PoolName, shootTf.position);
        movement.Move((Utilities.GetPlayerPos() - shootTf.position).normalized);

        projectiles.Add(movement);
    }

    public void MoveProjectiles()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].Move((Utilities.GetPlayerPos()));
        }
    }
}
