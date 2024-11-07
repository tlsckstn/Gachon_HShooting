using UnityEngine;

public class StatController : MonoBehaviour, IDamageable<StatSO, Stat>
{
    [field: SerializeField] public StatSO StatData { get; }

    private StatSO stat;

    public void TakeDamage(Stat attacker)
    {
        stat.TakeDamage(attacker);
    }

    private void Awake()
    {
        if(StatData == null)
        {
            Debug.LogError("Don't have StatData: " + gameObject.name);
            return;
        }

        stat = StatData.Clone() as StatSO;
    }
}