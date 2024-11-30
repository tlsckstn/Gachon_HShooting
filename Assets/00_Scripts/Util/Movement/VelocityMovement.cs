using UnityEngine;

/// <summary>
/// Rigidbody2D의 velocity를 사용해 특정 방향으로 움직임
/// </summary>
public class VelocityMovement : Movement
{
    [SerializeField] private Rigidbody2D rigid;

    public override void Move(Vector3 vec)
    {
        base.Move(vec);

        rigid.linearVelocity = vec * speed;
    }
}
