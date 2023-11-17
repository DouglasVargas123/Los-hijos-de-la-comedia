using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    private Rigidbody rb;
    public Transform raycastPoint;
    public ObjectsValue objectsValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public override void Interact()
    {
        base.Interact();
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = raycastPoint.transform.position;
        transform.SetParent(raycastPoint.gameObject.transform);
        

    }

    public override void Soltar()
    {
        base.Soltar();
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.position = transform.position;
        transform.SetParent(null);
    }
}
