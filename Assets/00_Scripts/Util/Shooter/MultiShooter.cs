using System.Collections.Generic;
using UnityEngine;

public abstract class MultiShooter : Shooter
{
    [SerializeField] protected List<Transform> shootTfs;

    public IReadOnlyList<Transform> ShootTfs => shootTfs;
}
