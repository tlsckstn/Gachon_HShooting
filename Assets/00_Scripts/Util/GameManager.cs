using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> playerPrefabs;

    protected override bool IsDontDestroy => true;
}