using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    private static PlayerController playerController;
    public static PlayerController GetPlayerController()
    {
        if (playerController == null)
            playerController = GameObject.FindAnyObjectByType<PlayerController>();

        return playerController;
    }
    public static Vector3 GetPlayerPos()
    {
        return GetPlayerController().transform.position;
    }
}