using UnityEngine;

public abstract class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] protected float shootDelay;
    [SerializeField] protected Transform shootTf;
    [SerializeField] protected Pool proejectilePool;

    public float ShootDelay => shootDelay;
    public Transform ShootTf => shootTf;
    public Transform ProejectilePool => shootTf;

    public abstract void Init();

    public abstract void Shoot();
}
