using UnityEngine;

public class DirectionMovement : MonoBehaviour, IMoveable
{
    public void Move(Vector3 vec, float speed)
    {
        transform.position += vec * speed * Time.deltaTime;
    }
}