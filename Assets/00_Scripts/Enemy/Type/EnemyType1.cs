using UnityEngine;

public class EnemyType1 : EnemyController
{
    private Vector3 respawnPos;

    public override void Init(Vector3 targetPos)
    {
        base.Init(targetPos);

        respawnPos = targetPos;
        movement.Move(Vector3.left);
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (transform.position.x <= EnemyManager.Instance.EnemyReturnPosX)
            transform.position = respawnPos;
    }
}