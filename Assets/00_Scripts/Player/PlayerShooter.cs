using UnityEngine;

public class PlayerShooter : SoloShooter
{
    public override void Init()
    {
        ObjectPool.Instance.RegisterPool(proejectilePool);
        InputManager.Instance.SetShootDelay(shootDelay);
    }

    public override void Shoot(Vector3 dir)
    {
        IMoveable movement = ObjectPool.Instance.GetObject<IMoveable>(proejectilePool.PoolName, shootTf.position);
        movement.Move(dir);
    }
}