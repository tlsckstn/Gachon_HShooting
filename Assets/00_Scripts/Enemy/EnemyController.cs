using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Movement movement;
    private IShootable shooter;
    private StatController statController;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        shooter = GetComponent<IShootable>();
        statController = GetComponent<StatController>();
    }

    public void OnUpdate(float deltaTime)
    {

    }
}
