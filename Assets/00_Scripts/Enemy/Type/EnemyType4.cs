using UnityEngine;

public class EnemyType4 : EnemyType1
{
    protected float shootDelay;

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);

        shootDelay = shooter.ShootDelay;
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        shootDelay -= deltaTime;
        if (shootDelay <= 0f)
        {
            shooter.Shoot(Vector3.left);
            shootDelay = shooter.ShootDelay;
        }
    }
}