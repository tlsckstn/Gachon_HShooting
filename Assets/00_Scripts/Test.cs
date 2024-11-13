using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] StatSO statSo;
    [SerializeField] Modifier modi;
    [SerializeField] Modifier modi2;
    [SerializeField] Modifier modi3;

    private void Awake()
    {
        StatSO stat = statSo.Clone() as StatSO;
        stat.Init();
        Debug.Log(stat.GetHp());

        stat.TakeDamage(5f);

        Debug.Log(stat.DamageStat.Value);
        stat.DamageStat.AddModifier(modi);
        stat.DamageStat.AddModifier(modi);
        stat.DamageStat.AddModifier(modi2);
        stat.DamageStat.AddModifier(modi3);
        Debug.Log(stat.DamageStat.Value);

    }
}
