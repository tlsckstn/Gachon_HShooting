using System;
using UnityEngine;

public class EnemyType2 : EnemyController
{
    protected bool isGoal;
    protected Vector3 targetPos;
    protected float shootDelay;

    protected Transform shootTf;

    protected override void Awake()
    {
        base.Awake();

        (movement as PointMovement).OnPointGoal += PointMovement_OnPointGoal;
    }

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);
        this.targetPos = targetPos;
        shootDelay = shooter.ShootDelay;
    }

    public override void OnUpdate(float deltaTime)
    {
        if (!isGoal)
        {
            movement.Move(targetPos);
            return;
        }

        shootDelay -= Time.deltaTime;
        if(shootDelay <= 0f)
        {
            shooter.Shoot((Utilities.GetPlayerPos() - shooter.ShootTfs[0].position).normalized);
            Debug.Log("A");
            shootDelay = shooter.ShootDelay;
        }
    }

    private void PointMovement_OnPointGoal()
    {
        isGoal = true;
        Debug.Log("Point");
    }
}