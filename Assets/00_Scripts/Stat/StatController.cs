using UnityEngine;

public class StatController : MonoBehaviour, IDamageable<StatSO, Stat>
{
    [SerializeField] private StatSO statData;

    public StatSO Stat { get; private set; }

    public void TakeDamage(Stat attacker)
    {
        Stat.TakeDamage(attacker);
    }

    private void Awake()
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