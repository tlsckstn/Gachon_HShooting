using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    [SerializeField] protected float additionalAngle;

    public abstract void Rotate(Vector3 dir);
}
