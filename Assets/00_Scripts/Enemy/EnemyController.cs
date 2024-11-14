using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMoveable movement;
    private IShootable shooter;
    private StatController statController;

    private void Awake()
    {
        movement = GetComponent<IMoveable>();
        shooter = GetComponent<IShootable>();
        statController = GetComponent<StatController>();
    }

    public void OnUpdate(float deltaTime)
    {

    }
}
