using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Movement movement;

    public Movement Movement => movement;
    public Shooter Owner { get; private set; }  

    public void Init(Shooter owner)
    {
        Owner = owner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(Owner.Damage);
            ReturnPool();
        }

        if (collision.CompareTag("Wall"))
        {
            ReturnPool();
        }
    }

    public void ReturnPool()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}