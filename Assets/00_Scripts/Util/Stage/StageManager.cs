using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    private const string STAGE_TEXT = "Stage ";

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

        stageText.text = STAGE_TEXT + stage;
    }

    /// <summary>
    /// StageData를 가져오는데 데이터들 중 AppliedStage 값이 현재 스테이지 값보다 가장 작은 것들 중 가장 뒤에 있는(가장 가까운 데이터값) 값을 가져옴
    /// </summary>
    /// <returns></returns>
    private StageData CalculateStageData() => datas.Last(x => x.AppliedStage <= stage);
}