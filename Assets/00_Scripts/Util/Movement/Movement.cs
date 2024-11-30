using UnityEngine;

/// <summary>
/// �⺻���� Movement Ŭ����
/// </summary>
public abstract class Movement : MonoBehaviour, IMoveable
{
    [SerializeField] protected float speed;
    [SerializeField] protected Rotator rotator;

    public float Speed => speed;

    public virtual void Move(Vector3 vec)
    {
        rotator?.Rotate(vec);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
