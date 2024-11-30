using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Pool ScriptableObject�� Ȱ���� ������Ʈ Ǯ���� �ϴ� ���
/// </summary>
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

    /// <summary>
    /// ������Ʈ�� �̸� or Pool�� PoolName ���� ���� �Ѿ���� �� ������ �˻�
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="position"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject GetObject(string poolName, Vector3 position, Transform parent = null)
    {
        Pool pool = GetPoolByName(poolName);
        if (pool == null)
        {
            Debug.LogError("�������� �ʴ� Pool�Դϴ�." + poolName);
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

    /// <summary>
    /// ���ϴ� ������Ʈ ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="poolName"></param>
    /// <param name="position"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public T GetObject<T>(string poolName, Vector3 position, Transform parent = null) where T : MonoBehaviour
        => GetObject(poolName, position, parent).GetComponent<T>();

    public void ReturnObject(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(transform);
        poolQueueDict[GetPoolByName(go.name)].Enqueue(go);
    }

    public Pool GetPoolByName(string poolName) => poolQueueDict.Keys.FirstOrDefault(x => x.PoolName.Equals(poolName));
}