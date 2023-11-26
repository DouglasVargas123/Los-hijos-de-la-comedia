using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private Transform raycastPoint;
    private Transform raycastGround;
    public float rayDistanceHand;
    public float rayDistanceGround;
    private MovementController movementController;
    private float originalSpeed;
    private float originalJumpForce;
    public InputManager inputManager;

    private Vector3 rayDirectionGround = Vector3.down;
    private Vector3 rayDirectionFront = Vector3.forward;

    private void Start()
    {
        raycastPoint = transform.Find("Raycast");
        raycastGround = transform.Find("RaycastGround");
        movementController = GetComponent<MovementController>();
        originalSpeed = movementController.playerSpeed;
        originalJumpForce = movementController.jumpForce;
    }

    private void Update()
    {
        Debug.DrawRay(raycastPoint.position, transform.TransformDirection(rayDirectionFront) * rayDistanceHand, Color.red);
        Debug.DrawRay(raycastGround.position, transform.TransformDirection(rayDirectionGround) * rayDistanceGround, Color.red);
        Platform();
    }

    public void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, transform.TransformDirection(rayDirectionFront), out hit, rayDistanceHand, LayerMask.GetMask("Interactable")))
        {
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

    public void Platform()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, transform.TransformDirection(rayDirectionGround), out hit, rayDistanceGround, LayerMask.GetMask("Platform")))
        {
            CharacterController characterController = hit.transform.GetComponent<CharacterController>();

            if (characterController != null)
            {
                CharacterController myCharacterController = GetComponent<CharacterController>();
                if (myCharacterController != null)
                {
                    myCharacterController.enabled = false;
                    myCharacterController.transform.SetParent(hit.transform);
                    myCharacterController.enabled = true;
                    myCharacterController.transform.localPosition = Vector3.zero;
                }
                else
                {
                    Debug.LogWarning("El objeto actual no tiene un CharacterController.");
                }
            }
            else
            {
                Debug.LogWarning("El objeto golpeado no tiene un CharacterController.");
            }
        }
    }
}