using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MultiShooter
{
    private List<IMoveable> projectiles = new();

    public override void Init()
    {
        
    }

    public override void Shoot(Vector3 dir)
    {
        for (int i = 0; i < shootTfs.Count; i++)
        {
            IMoveable movement = ObjectPool.Instance.GetObject<IMoveable>(proejectilePool.PoolName, shootTfs[i].position);
            movement.Move(dir);

            projectiles.Add(movement);
        }
    }

    public void MoveProjectiles()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].Move((Utilities.GetPlayerPos()));
        }
    }
}
