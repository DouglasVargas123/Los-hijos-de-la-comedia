using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public InputManagerController inputActions;
    [HideInInspector] public bool isJumping = false;
    [SerializeField] private InteractController interactController;
    [HideInInspector] public Vector3 dir;
    [SerializeField] private MovementController movementController;
    [SerializeField] private MenuManager menuManager;

    private void Awake()
    {
        inputActions = new InputManagerController();
        inputActions.Player.Enable();
    }

    public void OnEnable()
    {

        inputActions.Player.Jump.performed += JumpInput;
        inputActions.Player.Jump.canceled += JumpInput;

        inputActions.Player.Hold.performed += HoldInput;
        inputActions.Player.Hold.canceled += HoldInput;

        inputActions.Player.Pause.performed += PauseInput;
        inputActions.UI.Reanudar.performed += ReanudarInput;
    }

    private void ReanudarInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SwitchGameplay());
        }
    }

    private void PauseInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SwitchUI());
        }
    }

    public Vector3 MoveInput()
    {
        //Quizas no use
        return inputActions.Player.Movement.ReadValue<Vector2>();
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


    private IEnumerator SwitchUI()
    {
        inputActions.Player.Disable();
        movementController.isMoving = false;
        menuManager.SwitchMenu();
        yield return new WaitForSeconds(0.5f);
        inputActions.UI.Enable();



    }
    private  IEnumerator SwitchGameplay()
    {
        inputActions.UI.Disable();
        menuManager.SwitchGameplay();
        yield return new WaitForSeconds(0.5f);
        movementController.isMoving = true;
        inputActions.Player.Enable();
    }

    public void SwitchGameplayBoton()
    {
        StartCoroutine(SwitchGameplay());
    }
}
