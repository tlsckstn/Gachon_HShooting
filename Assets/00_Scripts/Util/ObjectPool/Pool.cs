using UnityEngine;

[CreateAssetMenu(fileName = "Pool", menuName = "Scriptable Objects/Pool")]
public class Pool : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string poolName;
    [SerializeField] private int poolCount;

    public GameObject Prefab => prefab;
    public string PoolName => poolName;
    public int PoolCount => poolCount;
}