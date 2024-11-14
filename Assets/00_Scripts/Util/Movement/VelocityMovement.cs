using UnityEngine;

public class VelocityMovement : Movement
{
    [SerializeField] private Rigidbody2D rigid;

    public override void Move(Vector3 vec)
    {
        rigid.linearVelocity = vec * speed;
    }
}
