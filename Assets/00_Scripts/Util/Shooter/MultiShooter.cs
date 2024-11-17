using System.Collections.Generic;
using UnityEngine;

public abstract class MultiShooter : Shooter
{
    public IReadOnlyList<Transform> ShootTfs { get; protected set; }
}
