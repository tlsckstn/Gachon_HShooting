using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField] private List<StageData> datas;
    [SerializeField] private int stage;
    [SerializeField] private TMP_Text stageText;

    private StageData currentStageData;

    protected override void Awake()
    {
        base.Awake();

        SetNextStage();
    }

    internal void SetNextStage()
    {
        stage++;
        currentStageData = CalculateStageData();
        EnemyManager.Instance.SetStageData(currentStageData);

        stageText.text = $"Stage {stage}";
    }

    private StageData CalculateStageData() => datas.Last(x => x.AppliedStage <= stage);
}