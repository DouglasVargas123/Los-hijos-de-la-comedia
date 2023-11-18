using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private Transform raycastPoint;
    public float rayDistance;
    private MovementController movementController;
    private float originalSpeed;
    private float originalJumpForce;
    public InputManager inputManager;

    private void Start()
    {
        raycastPoint = transform.Find("Raycast");
        movementController = GetComponent<MovementController>();
        originalSpeed = movementController.playerSpeed;
        originalJumpForce = movementController.jumpForce;
    }


    private void FixedUpdate()
    {
        Debug.DrawRay(raycastPoint.position, raycastPoint.forward * rayDistance, Color.red);
        RaycastHit hit;
        if (inputManager.isHolding)
        {
            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, rayDistance, LayerMask.GetMask("Interactuable")))
            {
                hit.transform.GetComponent<Interactable>().Interact();
                movementController.playerSpeed = movementController.playerSpeed - hit.transform.GetComponent<Pickable>().objectsValue.ObjectWeightSpeed;
                movementController.jumpForce = movementController.jumpForce - hit.transform.GetComponent<Pickable>().objectsValue.ObjectWeightJump;
                Debug.Log(hit.transform.GetComponent<Pickable>().objectsValue.ObjectName);
            }
        }
        if (!inputManager.isHolding)
        {
            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, rayDistance, LayerMask.GetMask("Interactuable")))
            {
                hit.transform.GetComponent<Interactable>().Soltar();
                movementController.playerSpeed = originalSpeed;
                movementController.jumpForce = originalJumpForce;
            }
        }
    }
}
