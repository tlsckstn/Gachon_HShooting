using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// LobbyScene과 GameScene의 중간다리 역할
/// 어떤 플레이어를 선택했는지 전달하고 플레이어가 죽으면 LobbyScene으로 돌아가는 역할
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
        // 두 번째로 StageScene에 진입하는 순간 알 수 없는 이유로 GameManager가 생성되며 selectPlayerIndex의 기본값이었던(현재는 -1) 0번째 플레이어 소환
        // 이벤트를 등록하는 함수를 Awake에서 Start로 옮기는 것으로 해결(DestroyImmidiate 함수가 제대로 작동하지 못한듯?)
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