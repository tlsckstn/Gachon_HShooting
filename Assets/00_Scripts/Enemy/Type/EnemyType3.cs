using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : EnemyType2
{
    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        shootDatas[0].shooter.MoveProjectiles();
    }
}