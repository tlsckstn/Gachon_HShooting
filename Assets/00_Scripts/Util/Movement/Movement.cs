using UnityEngine;

public abstract class Movement : MonoBehaviour, IMoveable
{
    [SerializeField] protected float speed;
    [SerializeField] protected bool isRotate;
    [SerializeField] protected Rotator rotator;

    public float Speed => speed;

    public virtual void Move(Vector3 vec)
    {
        if(isRotate)
        {
            rotator.Rotate(vec);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
