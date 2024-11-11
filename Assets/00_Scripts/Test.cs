using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] StatSO statSo;

    private void Awake()
    {
        StatSO stat = statSo.Clone() as StatSO;
        StatSO stat2 = statSo.Clone() as StatSO;
        stat.Init();
        stat2.Init();
        Debug.Log(statSo.GetHp());
        Debug.Log(stat.GetHp());
        Debug.Log(stat2.GetHp());

        stat.TakeDamage(5f);
        stat2.TakeDamage(1f);

        Debug.Log(statSo.GetHp());
        Debug.Log(stat.GetHp());
        Debug.Log(stat2.GetHp());
    }
}
