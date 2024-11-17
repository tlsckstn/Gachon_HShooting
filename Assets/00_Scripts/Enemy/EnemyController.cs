using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected Movement movement;
    [SerializeField] protected EnemyShooter shooter;
    [SerializeField] protected StatController statController;

    public bool IsPointMovement() => movement is PointMovement;
    public bool IsDirectionMovement() => movement is DirectionMovement;
    public bool IsVelocityMovement() => movement is VelocityMovement;

    protected virtual void Awake()
    {
        statController.Init();
        statController.OnUnitDied += ReturnPool;
    }

    public virtual void Init(Vector3 playerPos)
    {
        movement.SetSpeed(statController.Stats.SpeedStat.Value);
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
}