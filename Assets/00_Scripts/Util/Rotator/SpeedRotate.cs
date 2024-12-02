using UnityEngine;

/// <summary>
/// 지속적으로 호출해 서서히 바라보기
/// </summary>
public class SpeedRotate : Rotator
{
    [SerializeField] protected float rotateSpeed;

    protected Vector3 rotateVec = new();

    public override void Rotate(Vector3 dir)
    {
        dir = (dir - transform.position).normalized;
        rotateVec.z = GetAngle(dir) + additionalAngle;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotateVec), rotateSpeed * Time.deltaTime);
    }
}
