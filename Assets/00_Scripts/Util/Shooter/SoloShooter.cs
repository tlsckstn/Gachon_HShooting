using UnityEngine;

/// <summary>
/// 한 장소에서만 발사하면 SoloShooter를 상속받음
/// </summary>
public abstract class SoloShooter : Shooter
{
    [SerializeField] protected Transform shootTf;

    public Transform ShootTf => shootTf;
}
