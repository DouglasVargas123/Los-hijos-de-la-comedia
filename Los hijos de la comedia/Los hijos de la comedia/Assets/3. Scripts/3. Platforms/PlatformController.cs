using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody rb;
    public Transform[] platformPositions;
    public float platformSpeed;
    public CharacterController characterController;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;

    private void Start()
    {
        rb = transform.Find("Plataforma").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        rb.MovePosition(Vector3.MoveTowards(rb.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));

        if(Vector3.Distance(rb.position, platformPositions[nextPosition].position) <= 0)
        {
            actualPosition = nextPosition;
            nextPosition++;

            if(nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
}
