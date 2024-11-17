using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    protected override bool IsDontDestroy => true;

    [SerializeField] private List<GameObject> playerPrefabs;
    [SerializeField] private Vector3 spawnPos;
    private int selectPlayerIndex = 0;

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if(scene.buildIndex == 1)
        {
            Debug.Log(selectPlayerIndex);
            Instantiate(playerPrefabs[selectPlayerIndex], spawnPos, Quaternion.identity);
        }
    }

    public void SelectPlayerIndex(int selectPlayerIndex)
    {
        this.selectPlayerIndex = selectPlayerIndex;
        SceneManager.LoadScene(1);
    }
}