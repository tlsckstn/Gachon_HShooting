using UnityEngine;

public class StatController : MonoBehaviour, IDamageable<StatSO, Stat>
{
    [SerializeField] private StatSO statData;

    private StatSO stat;

    public void TakeDamage(Stat attacker)
    {
        stat.TakeDamage(attacker);
    }

    private void Awake()
    {
        if(statData == null)
        {
            Debug.LogError("Don't have StatData: " + gameObject.name);
            return;
        }

        stat = statData.Clone() as StatSO;
        stat.Init();
    }
}