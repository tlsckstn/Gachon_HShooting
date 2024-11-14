using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Shooter shooter;
    [SerializeField] private StatController statController;

    private void Awake()
    {
        statController.Init();
    }

    private void OnEnable()
    {
        movement.SetSpeed(statController.Stat.SpeedStat.Value);
        movement.Move(Vector3.left);
    }

    public void OnUpdate(float deltaTime)
    {
    }
}
