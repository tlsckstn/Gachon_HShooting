using UnityEngine;

/// <summary>
/// �� ��ҿ����� �߻��ϸ� SoloShooter�� ��ӹ���
/// </summary>
public abstract class SoloShooter : Shooter
{
    [SerializeField] protected Transform shootTf;

    public Transform ShootTf => shootTf;
}
