using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField] private List<StageData> datas;
    [SerializeField] private int stage;

    private StageData currentStageData;

    protected override void Awake()
    {
        base.Awake();
    }

    private StageData CalculateStageData() => datas.Last(x => x.AppliedStage <= stage);
}