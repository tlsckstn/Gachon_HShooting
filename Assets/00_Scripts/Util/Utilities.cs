using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    private static Dictionary<float, WaitForSeconds> waitDict = new();
    public static WaitForSeconds GetWait(float key)
    {
        if(!waitDict.ContainsKey(key))
            waitDict.Add(key, new WaitForSeconds(key));

        return waitDict[key];
    }
}