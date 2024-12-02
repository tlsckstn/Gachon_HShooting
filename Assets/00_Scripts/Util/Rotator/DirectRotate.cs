using UnityEngine;

/// <summary>
/// ���ϴ� ���� �ٷ� �ٶ󺸱�
/// </summary>
public class DirectRotate : Rotator
{
    public override void Rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.AngleAxis(GetAngle(dir) + additionalAngle, Vector3.forward);
    }
}
