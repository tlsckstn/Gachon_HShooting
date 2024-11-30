using UnityEngine;

/// <summary>
/// 원하는 방향 바로 바라보기
/// </summary>
public class DirectRotate : Rotator
{
    public override void Rotate(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + additionalAngle, Vector3.forward);
    }
}
