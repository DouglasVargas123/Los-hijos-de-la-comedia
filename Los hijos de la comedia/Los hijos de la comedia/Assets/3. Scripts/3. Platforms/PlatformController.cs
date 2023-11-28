using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody rb;
    public Transform[] platformPositions;
    public float platformSpeed;
    public CharacterController characterController;
    public bool Llego = false;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

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
        if (moveToTheNext)
        {
            StopCoroutine(waitForMove(0));
            rb.MovePosition(Vector3.MoveTowards(rb.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }


        if(Vector3.Distance(rb.position, platformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(waitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if(nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
    IEnumerator waitForMove(float Time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(Time);
        moveToTheNext = true;
    }

}
