using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� �߻��ϰ� �߻��ϴ� ��Ұ� ���� ���� ��쿡 �� ��ũ��Ʈ�� ��ӹ���
/// </summary>
public abstract class MultiShooter : Shooter
{
    public IReadOnlyList<Transform> ShootTfs { get; protected set; }
}
