using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Pool ScriptableObject를 활용해 오브젝트 풀링을 하는 방식
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
    /// 오브젝트의 이름 or Pool의 PoolName 변수 값이 넘어오고 그 값으로 검사
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

    /// <summary>
    /// 원하는 컴포넌트 리턴
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