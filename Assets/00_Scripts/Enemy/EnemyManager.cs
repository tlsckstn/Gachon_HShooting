using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<EnemyController> aliveEnemies = new();

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < aliveEnemies.Count; i++)
        {
            aliveEnemies[i].OnUpdate(deltaTime);
        }
    }
}