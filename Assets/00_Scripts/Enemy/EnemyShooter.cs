using UnityEngine;

public class EnemyShooter : Shooter
{
    public override void Init()
    {
        
    }

    public override void Shoot()
    {
        IMoveable movement = ObjectPool.Instance.GetObject<IMoveable>(proejectilePool.PoolName, shootTf.position);
        movement.Move((Utilities.GetPlayerPos() - shootTf.position).normalized);
    }
}
