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

        movement.Speed = statController.Stat.SpeedStat.Value;
        shooter.Init();

        InputManager.Instance.OnMovementInput += InputManager_OnMovementInput;
        InputManager.Instance.OnShootInput += InputManager_OnShootInput;
    }

    private void InputManager_OnMovementInput(InputData data)
    {
        movement.Move(data.inputDir);
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