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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            transform.position = respawnPos;
        }
    }
}