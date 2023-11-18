using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("PlayerMovement")]
    public float playerSpeed;
    private float fallVelocity;
    public float gravity;
    public float jumpForce;
    private float horizontalMove;
    private float verticalMove;
    private CharacterController player;
    private Vector3 playerInput;
    private Vector3 movePlayer;

    //Cam
    private Vector3 camForward;
    private Vector3 camRight;
    [Header("Anim")]
    public Animator anim;
    [Header("InputSystem")]
    [SerializeField] private InputManager inputActions;


    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MOVE();
    }

    private void MOVE()
    {
        CaptureInput();
        NormalizeInput();
        camDirection();
        CalculateMovement();
        SetGravity();
        PerformJump();
        ApplyMovement();
    }

    private void CaptureInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void NormalizeInput()
    {
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
    }

    public void camDirection()
    {
        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    private void CalculateMovement()
    {
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;
        anim.SetFloat("VelRun", player.velocity.magnitude);
        player.transform.LookAt(player.transform.position + movePlayer);
    }

    public void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    public void PerformJump()
    {
        if (player.isGrounded && inputActions.isJumping)
        {
            fallVelocity = jumpForce; //Caida
            movePlayer.y = fallVelocity; //Velocidad caida
            anim.SetBool("JumpPerform", player.isGrounded); //Animacion salto
        }
    }

    private void ApplyMovement()
    {
        player.Move(movePlayer * Time.deltaTime);
    }
}
