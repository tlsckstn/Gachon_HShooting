using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMoveable movement;
    private StatController statController;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<IMoveable>();
        statController = GetComponent<StatController>();
        playerAnimator = GetComponent<PlayerAnimator>();

        InputManager.Instance.OnMovementInput += InputManager_OnMovementInput;
    }

    private void InputManager_OnMovementInput(InputData data)
    {
        if(!data.IsZeroInput())
            movement.Move(data.inputDir, statController.Stat.SpeedStat.Value);

        playerAnimator?.SetMoveParameters(data.inputDir.y);
    }

    [ContextMenu("AA")]
    public void TestAA()
    {
        Debug.Log(InputManager.Instance == null);
    }
}