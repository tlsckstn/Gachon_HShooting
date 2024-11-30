using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 여러 개를 발사하고 발사하는 장소가 여러 곳일 경우에 이 스크립트를 상속받음
/// </summary>
public abstract class MultiShooter : Shooter
{
    public IReadOnlyList<Transform> ShootTfs { get; protected set; }
}
