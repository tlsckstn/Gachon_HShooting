using UnityEngine;

/// <summary>
/// 특정 방향으로 지속적으로 날아가는 클래스
/// </summary>
public class DirectionMovement : Movement
{
    public override void Move(Vector3 vec)
    {
        transform.position += vec * speed * Time.deltaTime;
    }
}