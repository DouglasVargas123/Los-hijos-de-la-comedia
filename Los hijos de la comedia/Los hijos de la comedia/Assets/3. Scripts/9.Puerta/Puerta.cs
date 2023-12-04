using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            if(other.gameObject.name == "Objeto1")
            {
                Debug.Log("Objeto 1 adentro");
            }
            else if(other.gameObject.name=="Objeto2")
            {
                Debug.Log("Objeto 2 adentro");
            }
            Debug.Log("objeto llego");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Objeto1")
        {
            Debug.Log("Objeto 1 afuera");
        }
        else if (other.gameObject.name == "Objeto2")
        {
            Debug.Log("Objeto 2 afuera");
        }
    }
}
