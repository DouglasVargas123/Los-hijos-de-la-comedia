using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private Transform raycastPoint;
    public float rayDistanceHand;
    public float rayDistanceGround;
    private MovementController movementController;
    private float originalSpeed;
    private float originalJumpForce;
    public InputManager inputManager;

    private Vector3 rayDirectionFront = Vector3.forward;

    private void Start()
    {
        raycastPoint = transform.Find("Raycast");
        movementController = GetComponent<MovementController>();
        originalSpeed = movementController.playerSpeed;
        originalJumpForce = movementController.jumpForce;
    }

    private void Update()
    {
        Debug.DrawRay(raycastPoint.position, transform.TransformDirection(rayDirectionFront) * rayDistanceHand, Color.red);
    }

    public void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, transform.TransformDirection(rayDirectionFront), out hit, rayDistanceHand, LayerMask.GetMask("Interactable")))
        {
            Debug.Log("Tocando");
            hit.transform.GetComponent<Interactable>().Interact();
            movementController.playerSpeed -= hit.transform.GetComponent<Pickable>().objectsValue.ObjectWeightSpeed;
            movementController.jumpForce -= hit.transform.GetComponent<Pickable>().objectsValue.ObjectWeightJump;
        }
    }

    public void Grabnt()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, transform.TransformDirection(rayDirectionFront), out hit, rayDistanceHand, LayerMask.GetMask("Interactable")))
        {
            hit.transform.GetComponent<Interactable>().Soltar();
            movementController.playerSpeed = originalSpeed;
            movementController.jumpForce = originalJumpForce;
        }
    }
}