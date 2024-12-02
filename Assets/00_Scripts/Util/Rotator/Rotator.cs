using UnityEngine;

public abstract class Rotator : MonoBehaviour, IRotateable
{
    [SerializeField] protected float additionalAngle;

    public abstract void Rotate(Vector3 dir);

    protected float GetAngle(Vector3 dir) => Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
}
