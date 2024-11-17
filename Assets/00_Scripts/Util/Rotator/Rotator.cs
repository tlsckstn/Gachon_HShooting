using UnityEngine;

public abstract class Rotator : MonoBehaviour, IRotateable
{
    [SerializeField] protected float additionalAngle;

    public abstract void Rotate(Vector3 dir);
}
