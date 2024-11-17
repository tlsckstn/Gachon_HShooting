using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Events
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDied;
    #endregion

    [SerializeField] private float limitX;
    [SerializeField] private float limitY;

    private Movement movement;
    private Shooter shooter;
    private StatController statController;

    private Vector3 pos;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        shooter = GetComponent<Shooter>();
        statController = GetComponent<StatController>();

        statController.Init();
        statController.OnUnitDied += StatController_OnUnitDied;
        movement.SetSpeed(statController.GetSpeedValue());
        shooter.Init(statController.GetDamageValue());

        InputManager.Instance.OnMovementInput += InputManager_OnMovementInput;
        InputManager.Instance.OnShootInput += InputManager_OnShootInput;
    }

    private void StatController_OnUnitDied()
    {
        OnPlayerDied?.Invoke();
    }

    private void InputManager_OnMovementInput(InputData data)
    {
        movement.Move(data.inputDir);
        LimitPosition();
    }

    private void InputManager_OnShootInput(InputData data)
    {
        shooter.Shoot(Vector3.right);
    }

    private void LimitPosition()
    {
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
        pos.y = Mathf.Clamp(pos.y, -limitY, limitY);
        transform.position = pos;
    }
}