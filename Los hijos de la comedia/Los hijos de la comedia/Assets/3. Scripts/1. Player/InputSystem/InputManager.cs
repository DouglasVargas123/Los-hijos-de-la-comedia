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
    [SerializeField] private InteractController interactController;
    [HideInInspector] public Vector3 dir;

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

    public Vector3 MoveInput()
    {
        return inputActions.Player.Movement.ReadValue<Vector3>();
    }

    private void Update()
    {
        Debug.Log(MoveInput());
    }

    private void HoldInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactController.Grab();
        }
        else if (context.canceled)
        {
            interactController.Grabnt();
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
