using UnityEngine;

public class VelocityMovement : MonoBehaviour, IMoveable
{
    [field: SerializeField] public float Speed { get; set; }
    [SerializeField] private Rigidbody2D rigid;

    public void Move(Vector3 vec)
    {
        rigid.linearVelocity = vec * Speed;
    }
}
