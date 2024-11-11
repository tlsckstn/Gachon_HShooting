using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public delegate void InputHandler(InputData data);
    public event InputHandler OnMovementInput;

    private InputData data = new();

    private void Update()
    {
        data.inputDir.x = Input.GetAxisRaw("Horizontal");
        data.inputDir.y = Input.GetAxisRaw("Vertical");

        data.inputDir.Normalize();
        OnMovementInput?.Invoke(data);
    }
}

public struct InputData
{
    public Vector3 inputDir;

    public bool IsZeroInput() 
        => Mathf.Approximately(inputDir.x, 0) && 
            Mathf.Approximately(inputDir.y, 0);
}