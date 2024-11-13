using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMoveable movement;
    private IShootable shooter;
    private StatController statController;

    private void Awake()
    {
        movement = GetComponent<IMoveable>();
        shooter = GetComponent<IShootable>();
        statController = GetComponent<StatController>();

        shooter.Init();

        InputManager.Instance.OnMovementInput += InputManager_OnMovementInput;
        InputManager.Instance.OnShootInput += InputManager_OnShootInput;
    }

    private void InputManager_OnMovementInput(InputData data)
    {
        movement.Move(data.inputDir, statController.Stat.SpeedStat.Value);
    }

    private void InputManager_OnShootInput(InputData data)
    {
        shooter.Shoot();
    }

    [ContextMenu("AA")]
    public void TestAA()
    {
        Debug.Log(InputManager.Instance == null);
    }
}