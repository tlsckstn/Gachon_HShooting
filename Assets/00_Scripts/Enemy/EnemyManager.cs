using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private List<Pool> enemyPools = new();
    [SerializeField] private List<Pool> enemyProjectilePools = new();

    [Space]
    [SerializeField] private Vector3 spawnPosTest;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float enemyReturnPosX = -15f;

    private List<EnemyController> aliveEnemies = new();
    private float baseSpawnDelay;

    public float EnemyReturnPosX => enemyReturnPosX;

    protected override void Awake()
    {
        base.Awake();

        baseSpawnDelay = spawnDelay;

        for (int i = 0; i < enemyPools.Count; i++)
        {
            ObjectPool.Instance.RegisterPool(enemyPools[i]);    
        }

        for (int i = 0; i < enemyProjectilePools.Count; i++)
        {
            ObjectPool.Instance.RegisterPool(enemyProjectilePools[i]);
        }
    }

    private void Update()
    {
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

    private void SpawnEnemy()
    {
        Pool enemyPool = enemyPools[Random.Range(0, enemyPools.Count)];
        EnemyController enemy = ObjectPool.Instance.GetObject<EnemyController>(enemyPool.PoolName, spawnPosTest);

        if (enemy.IsPointMovement())
            enemy.Init(spawnPosTest + Vector3.left * 3f);
        else
            enemy.Init(spawnPosTest);

        aliveEnemies.Add(enemy);

        spawnDelay = baseSpawnDelay;
    }

    private void SpawnBoss()
    {
        Pool enemyPool = enemyPools[Random.Range(0, enemyPools.Count)];
        EnemyController enemy = ObjectPool.Instance.GetObject<EnemyController>(enemyPool.PoolName, spawnPosTest);

        enemy.Init(spawnPosTest + Vector3.left * 5f);

        aliveEnemies.Add(enemy);
    }
}