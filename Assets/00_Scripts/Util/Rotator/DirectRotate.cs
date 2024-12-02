using UnityEngine;

/// <summary>
/// 원하는 방향 바로 바라보기
/// </summary>
public class DirectRotate : Rotator
{
    public override void Rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.AngleAxis(GetAngle(dir) + additionalAngle, Vector3.forward);
    }
}
