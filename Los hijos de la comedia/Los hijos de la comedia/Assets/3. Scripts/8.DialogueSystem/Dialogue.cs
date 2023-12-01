using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    private bool isPlayerInRange;


    // Update is called once per frame
    void Update()
    {
        
    }
    
 
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Se puede iniciar un dialogo");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No se puede iniciar un dialogo");
        }
    }


}
