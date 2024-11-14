using UnityEngine;

public class StatController : MonoBehaviour, IDamageable
{
    [SerializeField] private StatSO statData;

    public StatSO Stat { get; private set; }

    public void TakeDamage(float damage)
    {
        Stat.TakeDamage(damage);
    }

    public void Init()
    {
        if(statData == null)
        {
            Debug.LogError("Don't have StatData: " + gameObject.name);
            return;
        }

        Stat = statData.Clone() as StatSO;
        Stat.Init();
    }
}