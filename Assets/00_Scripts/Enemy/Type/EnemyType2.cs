using System;
using UnityEngine;

public class EnemyType2 : EnemyController
{
    protected bool isGoal;
    protected Vector3 targetPos;

    protected Transform shootTf;

    protected override void Awake()
    {
        base.Awake();

        (movement as PointMovement).OnPointGoal += PointMovement_OnPointGoal;
    }

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);

        isGoal = false;
        this.targetPos = targetPos;
        isGoal = false;
    }

    public override void OnUpdate(float deltaTime)
    {
        if (!isGoal)
        {
            movement.Move(targetPos);
            return;
        }

        shootDelay -= deltaTime;
        if(shootDelay <= 0f)
        {
            GetBaseShooter().Shoot((Utilities.GetPlayerPos() - GetBaseShootTf().position).normalized);
            ResetShootDelay();
        }
    }

    private void PointMovement_OnPointGoal()
    {
        isGoal = true;
        Debug.Log("Point");
    }
}