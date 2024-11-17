using UnityEngine;

public class EnemyType4 : EnemyType1
{
    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        shootDelay -= deltaTime;
        if (shootDelay <= 0f)
        {
            for (int i = 0; i < shootDatas.Count; i++)
            {
                shootDatas[i].shooter.Shoot(Vector3.left);
            }
            ResetShootDelay();
        }
    }
}