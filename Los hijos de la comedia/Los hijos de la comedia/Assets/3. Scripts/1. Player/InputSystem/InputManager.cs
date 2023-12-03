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
    [SerializeField] private PlatformController[] platformController;
    [SerializeField] private Enemy[] enemy;

    private int VelocidadOriginalEnemigoDeSeguirAlJugador;
    private int VelocidadOriginalEnemigoDeSeguirPuntos;

    private float inicio =5000.00f;
    private float final = 300.00f; 

    private void Awake()
    {
        inputActions = new InputManagerController();
        inputActions.Player.Enable();

    }

    private void Start()
    {
        VelocidadOriginalEnemigoDeSeguirAlJugador = enemy[0].velocidadSeguirJugador;
        VelocidadOriginalEnemigoDeSeguirPuntos = enemy[0].VelocidadSeguirPuntos;
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
            StartCoroutine(AudioManager.instance.LowPassSmoothTransition(final,inicio));

        }
    }

    private void PauseInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SwitchUI());
            StartCoroutine(AudioManager.instance.LowPassSmoothTransition(inicio,final));
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
        ValocidadEnCero();
        yield return new WaitForSeconds(0.5f);
        inputActions.UI.Enable();



    }
    private  IEnumerator SwitchGameplay()
    {
        inputActions.UI.Disable();
        menuManager.SwitchGameplay();
        yield return new WaitForSeconds(0.5f);
        movementController.isMoving = true;
        VelocidadNormal();
        inputActions.Player.Enable();
    }

    public void SwitchGameplayBoton()
    {
        StartCoroutine(SwitchGameplay());
    }

    public void ValocidadEnCero()
    {
        platformController[0].platformSpeed = 0;
        platformController[1].platformSpeed = 0;
        platformController[2].platformSpeed = 0;
        platformController[3].platformSpeed = 0;
        platformController[4].platformSpeed = 0;

        enemy[0].velocidadSeguirJugador = 0;
        enemy[0].VelocidadSeguirPuntos = 0;
    }

    public void VelocidadNormal()
    {
        platformController[0].platformSpeed = 5;
        platformController[1].platformSpeed = 5;
        platformController[2].platformSpeed = 5;
        platformController[3].platformSpeed = 7;
        platformController[4].platformSpeed = 7;

        enemy[0].velocidadSeguirJugador = VelocidadOriginalEnemigoDeSeguirAlJugador;
        enemy[0].VelocidadSeguirPuntos = VelocidadOriginalEnemigoDeSeguirPuntos;
    }


}
