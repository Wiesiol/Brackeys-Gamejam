using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput input;
    public PlayerInput Input => input;

    private void Awake()
    {
        input = new();
        input.Gameplay.Enable();
    }
}
