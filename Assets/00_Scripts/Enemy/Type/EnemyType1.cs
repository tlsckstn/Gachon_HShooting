using UnityEngine;

public class EnemyType1 : EnemyController
{
    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);

        movement.Move(Vector3.left);
    }
}