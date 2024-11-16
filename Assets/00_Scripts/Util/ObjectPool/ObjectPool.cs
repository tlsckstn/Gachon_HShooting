using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    private Dictionary<Pool, Queue<GameObject>> poolQueueDict = new();

    private void CreateObject(Pool pool)
    {
        for (int i = 0; i < pool.PoolCount; i++)
        {
            GameObject go = Instantiate(pool.Prefab);
            go.name = pool.PoolName;
            go.transform.SetParent(transform);
            go.SetActive(false);
            poolQueueDict[pool].Enqueue(go);
        }
    }

    public void RegisterPool(Pool pool)
    {
        poolQueueDict.Add(pool, new Queue<GameObject>());
        CreateObject(pool);
    }

    public GameObject GetObject(string poolName, Vector3 position, Transform parent = null)
    {
        Pool pool = GetPoolByName(poolName);
        if (pool == null)
        {
            Debug.LogError("존재하지 않는 Pool입니다." + poolName);
            return null;
        }

        if (poolQueueDict[pool].Count == 0)
            CreateObject(pool);

        GameObject go = poolQueueDict[pool].Dequeue();

        if (parent != null)
            go.transform.SetParent(parent);

        go.transform.position = position;
        go.SetActive(true);

        return go;
    }

    public T GetObject<T>(string poolName, Vector3 position, Transform parent = null)
        => GetObject(poolName, position, parent).GetComponent<T>();

    public void ReturnObject(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(transform);
        poolQueueDict[GetPoolByName(go.name)].Enqueue(go);
    }

    public Pool GetPoolByName(string poolName) => poolQueueDict.Keys.FirstOrDefault(x => x.PoolName.Equals(poolName));
}