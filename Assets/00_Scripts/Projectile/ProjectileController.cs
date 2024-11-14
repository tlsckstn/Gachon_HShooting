using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private IMoveable movement;

    private void Awake()
    {
        movement = GetComponent<IMoveable>();
    }

    private void OnEnable()
    {
        movement.Move(Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}