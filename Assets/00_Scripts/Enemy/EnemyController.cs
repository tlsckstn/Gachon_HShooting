using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected Movement movement;
    [SerializeField] protected List<ShootData> shootDatas;
    [SerializeField] protected StatController statController;

    protected float shootDelay;

    public Transform GetBaseShootTf() => shootDatas[0].shootTfs[0];
    public EnemyShooter GetBaseShooter() => shootDatas[0].shooter;

    public bool IsPointMovement() => movement is PointMovement;
    public bool IsDirectionMovement() => movement is DirectionMovement;
    public bool IsVelocityMovement() => movement is VelocityMovement;

    protected virtual void Awake()
    {
        statController.Init();
        statController.OnUnitDied += ReturnPool;

        for (int i = 0; i < shootDatas.Count; i++)
        {
            shootDatas[i].shooter.SetShootTfs(shootDatas[i].shootTfs);
        }
    }

    public virtual void Init(Vector3 playerPos)
    {
        movement.SetSpeed(statController.Stats.SpeedStat.Value);
        ResetShootDelay();
    }

    public virtual void OnUpdate(float deltaTime)
    {
    }

    public virtual void StatController_OnUnitDied()
    {
        ReturnPool();
    }

    public virtual void ReturnPool()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }

    protected void ResetShootDelay()
    {
        if (shootDatas.Count == 0)
            return;

        shootDelay = GetBaseShooter().ShootDelay;
    }
}

[System.Serializable]
public struct ShootData
{
    public EnemyShooter shooter;
    public List<Transform> shootTfs;
}