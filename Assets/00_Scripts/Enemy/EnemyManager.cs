using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy들을 관리하는 EnemyManager 스크립트
/// Enemy들의 생성 데이터를 가진 Pool들과 Enemy들의 Proejctile 생성 데이터를 가진 Pool들을 List 형태로 가지고 있음
/// aliveEnemies List에 현재 살아있는 Enemy들이 담기며 Enemy가 죽을 시 저 리스트에서 제외됨
/// Stage에 할당된 모든 Enemy가 죽었을 때 다음 스테이지로 넘어감
/// </summary>
public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private List<Pool> enemyPools = new();
    [SerializeField] private List<Pool> enemyProjectilePools = new();

    [Space]
    [SerializeField] private float spawnPosX;
    [SerializeField] private float spawnPosY;
    [SerializeField] private float spawnPointMultipleValue;

    [Space]
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;

    private List<EnemyController> aliveEnemies = new();
    private Vector3 spawnPos;

    private StageData currentStageData;
    private int spawnCount;
    private bool isReadyStage = false;

    private bool IsStageClear => spawnCount <= 0 && aliveEnemies.Count == 0;

    protected override void Awake()
    {
        base.Awake();

        spawnPos.x = spawnPosX;

        for (int i = 0; i < enemyPools.Count; i++)
        {
            ObjectPool.Instance.RegisterPool(enemyPools[i]);    
        }

        for (int i = 0; i < enemyProjectilePools.Count; i++)
        {
            ObjectPool.Instance.RegisterPool(enemyProjectilePools[i]);
        }
    }

    public void SetStageData(StageData data)
    {
        currentStageData = data;
        spawnCount = currentStageData.SpawnCount;
        isReadyStage = true;
    }

    private void Update()
    {
        if (!isReadyStage)
            return;

        if (IsStageClear)
            SetNextStage();

        float deltaTime = Time.deltaTime;
        for (int i = 0; i < aliveEnemies.Count; i++)
        {
            aliveEnemies[i].OnUpdate(deltaTime);
        }

        spawnDelay -= deltaTime;
        if(spawnDelay <= 0)
        {
            SpawnEnemy();
        }
    }

    private void SetNextStage()
    {
        isReadyStage = false;
        StageManager.Instance.SetNextStage();
    }

    private void SpawnEnemy()
    {
        spawnPos.y = Random.Range(-spawnPosY, spawnPosY);

        Pool enemyPool = enemyPools[Random.Range(0, enemyPools.Count)];
        EnemyController enemy = ObjectPool.Instance.GetObject<EnemyController>(enemyPool.PoolName, spawnPos);

        if (enemy.IsPointMovement())
            enemy.Init(spawnPos + (Vector3.left * spawnPointMultipleValue));
        else
            enemy.Init(spawnPos);

        enemy.ReturnAllIncrease();
        enemy.IncreaseStat(currentStageData.AdditionalHp, currentStageData.AdditionalDamage);
        aliveEnemies.Add(enemy);

        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        spawnCount--;
    }

    public void ReturnEnemy(EnemyController enemy)
    {
        aliveEnemies.Remove(enemy);
    }
}