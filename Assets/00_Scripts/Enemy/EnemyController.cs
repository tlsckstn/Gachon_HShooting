using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected Movement movement;
    [SerializeField] protected Shooter shooter;
    [SerializeField] protected StatController statController;

    public bool IsPointMovement() => movement is PointMovement;
    public bool IsDirectionMovement() => movement is DirectionMovement;
    public bool IsVelocityMovement() => movement is VelocityMovement;

    protected virtual void Awake()
    {
        statController.Init();
    }

    public virtual void Init(Vector3 playerPos)
    {
        movement.SetSpeed(statController.Stats.SpeedStat.Value);
    }

    public virtual void OnUpdate(float deltaTime)
    {
    }

    public virtual void ReturnPool()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}