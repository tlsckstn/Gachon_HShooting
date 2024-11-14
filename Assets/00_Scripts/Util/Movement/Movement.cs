using UnityEngine;

public abstract class Movement : MonoBehaviour, IMoveable
{
    [SerializeField] protected float speed;

    public float Speed => speed;

    public abstract void Move(Vector3 vec);
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
