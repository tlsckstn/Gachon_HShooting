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
    /// StageData�� �������µ� �����͵� �� AppliedStage ���� ���� �������� ������ ���� ���� �͵� �� ���� �ڿ� �ִ�(���� ����� �����Ͱ�) ���� ������
    /// </summary>
    /// <returns></returns>
    private StageData CalculateStageData() => datas.Last(x => x.AppliedStage <= stage);
}