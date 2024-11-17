using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        movement.SetSpeed(statController.Stats.SpeedStat.Value);
        shooter.Init();

        InputManager.Instance.OnMovementInput += InputManager_OnMovementInput;
        InputManager.Instance.OnShootInput += InputManager_OnShootInput;
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

    [ContextMenu("AA")]
    public void TestAA()
    {
        Debug.Log(InputManager.Instance == null);
    }
}