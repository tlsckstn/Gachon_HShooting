using UnityEngine;

public class PointMovement : Movement
{
    public delegate void PointGoalHandler();
    public event PointGoalHandler OnPointGoal;

    public override void Move(Vector3 vec)
    {
        transform.position = Vector3.MoveTowards(transform.position, vec, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, vec) <= 0.1f)
        {
            transform.position = vec;
            OnPointGoal?.Invoke();
        }
    }
}
