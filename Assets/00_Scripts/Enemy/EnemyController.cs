using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy들이 상속받을 기본 Controller 스크립트
/// 다양한 공격을 구사하기 때문에 Shooter 대신 ShootData를 List 형태로 가지고 있음
/// 유니티의 Update 함수 대신 EnemyManager에서 OnUdpate(Time.deltaTime) 방식으로 호출
/// </summary>
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
        statController.OnUnitDied += StatController_OnUnitDied;

        for (int i = 0; i < shootDatas.Count; i++)
        {
            shootDatas[i].shooter.Init(statController.GetDamageValue());
            shootDatas[i].shooter.SetShootTfs(shootDatas[i].shootTfs);
        }
    }

    public virtual void Init(Vector3 playerPos)
    {
        movement.SetSpeed(statController.GetSpeedValue());
        ResetShootDelay();
    }

    public virtual void OnUpdate(float deltaTime)
    {
    }

    public virtual void StatController_OnUnitDied()
    {
        EnemyManager.Instance.ReturnEnemy(this);
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

    public void IncreaseStat(float hpAmount, Modifier modifier)
    {
        statController.TryIncreaseStat(hpAmount, modifier);
    }

    public void ReturnAllIncrease()
    {
        statController.ReturnAllIncrease();
    }
}

[System.Serializable]
public struct ShootData
{
    public EnemyShooter shooter;
    public List<Transform> shootTfs;
}