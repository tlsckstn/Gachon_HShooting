using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public delegate void InputHandler(InputData data);
    public event InputHandler OnMovementInput;
    public event InputHandler OnShootInput;

    private InputData data = new();

    public void SetShootDelay(float shootDelay)
    {
        data.SetShootDelay(shootDelay);
    }

    private void Update()
    {
        MovementInput();
        ShootInput();
    }

    private void MovementInput()
    {
        data.inputDir.x = Input.GetAxisRaw("Horizontal");
        data.inputDir.y = Input.GetAxisRaw("Vertical");

        if (!data.IsZeroInput())
        {
            //data.inputDir.Normalize();
            OnMovementInput?.Invoke(data);
        }
    }

    private void ShootInput()
    {
        data.shootDelay -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            if (data.IsShootable())
            {
                OnShootInput?.Invoke(data);
                data.ResetShootDelay();
            }
        }
    }
}

public struct InputData
{
    public Vector3 inputDir;
    public float shootDelay;
    public float baseShootDelay;

    public bool IsZeroInput()
        => Mathf.Approximately(inputDir.x, 0) &&
            Mathf.Approximately(inputDir.y, 0);

    public void SetShootDelay(float baseShootDelay) => this.baseShootDelay = baseShootDelay;
    public bool IsShootable() => shootDelay <= 0f;
    public void ResetShootDelay() => shootDelay = baseShootDelay;
}