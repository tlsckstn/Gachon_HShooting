using System.Collections.Generic;
using UnityEngine;

public class EnemyType5Shooter : Shooter
{
    [SerializeField] protected List<ShootData> shootDatas;

    public IReadOnlyList<ShootData> ShootDatas => shootDatas;

    public override void Init()
    {

    }

    public override void Shoot(Vector3 dir)
    {
        //shooters[Random.Range(0, shooters.Count)].Shoot(Vector3.zero);
    }
}

[System.Serializable]
public struct ShootData
{
    public Shooter shooter;
    public List<Transform> shootTfs;
}