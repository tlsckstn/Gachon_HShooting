using UnityEngine;

/// <summary>
/// Ư�� �������� ���������� ���ư��� Ŭ����
/// </summary>
public class DirectionMovement : Movement
{
    public override void Move(Vector3 vec)
    {
        transform.position += vec * speed * Time.deltaTime;
    }
}