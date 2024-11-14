using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Movement movement;

    private void OnEnable()
    {
        movement.Move(Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}