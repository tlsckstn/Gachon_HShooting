using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        spawnPos.y = Random.Range(-spawnPosY, spawnPosY);

        Pool enemyPool = enemyPools[Random.Range(0, enemyPools.Count)];
        EnemyController enemy = ObjectPool.Instance.GetObject<EnemyController>(enemyPool.PoolName, spawnPos);

        if (enemy.IsPointMovement())
            enemy.Init(spawnPos + (Vector3.left * spawnPointMultipleValue));
        else
            enemy.Init(spawnPos);

        aliveEnemies.Add(enemy);

        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    public void ReturnEnemy(EnemyController enemy)
    {
        aliveEnemies.Remove(enemy);
    }
}