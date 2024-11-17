using UnityEngine;

public abstract class SoloShooter : Shooter
{
    [SerializeField] protected Transform shootTf;

    public Transform ShootTf => shootTf;
}
