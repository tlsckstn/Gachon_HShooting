using UnityEngine;

public abstract class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] protected float shootDelay;
    [SerializeField] protected Transform shootTf;

    public abstract void Init();

    public abstract void Shoot();
}
