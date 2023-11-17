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
    [Header("CAM")]
    public Camera mainCam;
    private Vector3 camForward;
    private Vector3 camRight;
    [Header("Anim")]
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        MOVE();
    }

    private void MOVE()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;
        anim.SetFloat("VelRun", player.velocity.magnitude);

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PerformJump();

        player.Move(movePlayer * Time.deltaTime);
    }

    public void camDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
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
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce; //Caida
            movePlayer.y = fallVelocity; //Velocidad caida
            anim.SetBool("JumpPerform", player.isGrounded); //Animacion salto
        }
    }
}
