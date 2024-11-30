using UnityEngine;

/// <summary>
/// ÃÑ¾Ë °ü¸®
/// </summary>
public class ProjectileController : MonoBehaviour
{
    public static readonly string TAG_WALL = "Wall";

    [SerializeField] private Movement movement;

    private float damage;

    public Movement Movement => movement;

    public void Init(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
            ReturnPool();
        }

        if (collision.CompareTag(TAG_WALL))
        {
            ReturnPool();
        }
    }

    public void ReturnPool()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}