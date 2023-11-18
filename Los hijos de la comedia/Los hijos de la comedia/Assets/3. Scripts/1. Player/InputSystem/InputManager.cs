using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputManagerController inputActions;
    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isHolding = false;

    private void Awake()
    {
        inputActions = new InputManagerController();
    }

    public void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += JumpInput;
        inputActions.Player.Jump.canceled += JumpInput;

        inputActions.Player.Hold.performed += HoldInput;
        inputActions.Player.Hold.canceled += HoldInput;
    }

    private void HoldInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isHolding = true;
        }
        else if (context.canceled)
        {
            isHolding = false;
        }
    }

    private void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
        else if (context.canceled)
        {
            isJumping = false;
        }
    }
}