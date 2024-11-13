using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private IMoveable movement;

    private void Awake()
    {
        movement = GetComponent<IMoveable>();
    }

    private void Update()
    {
        movement.Move(transform.right, 15f);
    }
}