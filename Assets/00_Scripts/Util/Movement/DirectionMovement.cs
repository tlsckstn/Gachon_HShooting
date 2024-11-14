using UnityEngine;

public class DirectionMovement : MonoBehaviour, IMoveable
{
    public float Speed { get; set; }

    public void Move(Vector3 vec)
    {
        transform.position += vec * Speed * Time.deltaTime;
    }
}