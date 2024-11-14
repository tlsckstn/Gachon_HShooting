using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Pool> enemyPools = new();
    [SerializeField] private Vector3 spawnPosTest;
    [SerializeField] private float spawnDelay;

    private List<EnemyController> aliveEnemies = new();
    private float baseSpawnDelay;

    private void Awake()
    {
        baseSpawnDelay = spawnDelay;

        for (int i = 0; i < enemyPools.Count; i++)
        {
            ObjectPool.Instance.RegisterPool(enemyPools[i]);    
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
        spawnPosTest += Vector3.left * 3;
        enemy.Init(spawnPosTest);
        aliveEnemies.Add(enemy);

        spawnDelay = baseSpawnDelay;
    }
}