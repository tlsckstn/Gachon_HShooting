using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/StageData")]
public class StageData : ScriptableObject
{
    [SerializeField] private int appliedStage;   
    [SerializeField] private float additionalHp;   
    [SerializeField] private Modifier additionalDamage;

    public int AppliedStage => appliedStage;
    public float AdditionalHp => additionalHp;
    public Modifier AdditionalDamage => additionalDamage;
}