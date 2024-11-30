using UnityEngine;

/// <summary>
/// 특정 위치로 이동하는 클래스
/// 도착 시 OnPointGoal 이벤트 실행
/// </summary>
public class PointMovement : Movement
{
    public delegate void PointGoalHandler();
    public event PointGoalHandler OnPointGoal;

    public override void Move(Vector3 vec)
    {
        base.Move(vec);

        transform.position = Vector3.MoveTowards(transform.position, vec, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, vec) <= 0.1f)
        {
            transform.position = vec;
            OnPointGoal?.Invoke();
        }
    }
}
