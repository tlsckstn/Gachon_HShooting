using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// LobbyScene�� GameScene�� �߰��ٸ� ����
/// � �÷��̾ �����ߴ��� �����ϰ� �÷��̾ ������ LobbyScene���� ���ư��� ����
/// </summary>
public class GameManager : Singleton<GameManager>
{
    protected override bool IsDontDestroy => true;

    [SerializeField] private List<GameObject> playerPrefabs;
    [SerializeField] private Vector3 spawnPos;

    private int selectPlayerIndex = -1;
    private bool isFirst = true;

    private void Start()
    {
        if (isFirst)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            PlayerController.OnPlayerDied += PlayerController_OnPlayerDied;
            isFirst = false;
        }
    }

    private void PlayerController_OnPlayerDied(Stat hpStat)
    {
        SceneManager.LoadScene(0);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        // �� ��°�� StageScene�� �����ϴ� ���� �� �� ���� ������ GameManager�� �����Ǹ� selectPlayerIndex�� �⺻���̾���(����� -1) 0��° �÷��̾� ��ȯ
        // �̺�Ʈ�� ����ϴ� �Լ��� Awake���� Start�� �ű�� ������ �ذ�(DestroyImmidiate �Լ��� ����� �۵����� ���ѵ�?)
        if (scene.buildIndex == 1)
        {
            if(selectPlayerIndex != -1) 
                Instantiate(playerPrefabs[selectPlayerIndex], spawnPos, Quaternion.identity);
        }
    }

    public void SelectPlayerIndex(int selectPlayerIndex)
    {
        this.selectPlayerIndex = selectPlayerIndex;
        SceneManager.LoadScene(1);
    }
}