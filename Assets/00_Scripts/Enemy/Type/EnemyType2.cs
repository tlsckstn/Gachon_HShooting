using System;
using UnityEngine;

public class EnemyType2 : EnemyController
{
    private bool isGoal;
    private Vector3 targetPos;

    protected override void Awake()
    {
        base.Awake();

        (movement as PointMovement).OnPointGoal += PointMovement_OnPointGoal;
    }

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);
        this.targetPos = targetPos;
    }

    public override void OnUpdate(float deltaTime)
    {
        if (!isGoal)
        {
            movement.Move(targetPos);
            return;
        }


    }

    private void PointMovement_OnPointGoal()
    {
        isGoal = true;
        Debug.Log("Point");
    }
}