using UnityEngine;

public class SpeedRotate : Rotator
{
    [SerializeField] protected float rotateSpeed;

    public override void Rotate(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle + additionalAngle)), rotateSpeed * Time.deltaTime);
    }
}
