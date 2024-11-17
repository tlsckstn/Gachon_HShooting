using System.Collections.Generic;
using UnityEngine;

public class EnemyType5 : EnemyController
{
    protected float shootDelay;
    protected bool isGoal;
    protected Vector3 targetPos;

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);

        this.targetPos = targetPos;
        shootDelay = shooter.ShootDelay;
        (movement as PointMovement).OnPointGoal += PointMovement_OnPointGoal;
    }

    public override void OnUpdate(float deltaTime)
    {
        if (!isGoal)
        {
            movement.Move(targetPos);
            return;
        }

        shootDelay -= deltaTime;
        if (shootDelay <= 0f)
        {
            shooter.Shoot(Vector3.zero);
            shootDelay = shooter.ShootDelay;
        }
    }

    private void PointMovement_OnPointGoal()
    {
        isGoal = true;
    }
}