using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPlataforma : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Realizar acciones espec�ficas cuando hay una colisi�n f�sica.
        Debug.Log("�Colisi�n detectada!");

        // Puedes acceder al objeto con el que colision� a trav�s de la variable "collision".
        GameObject objetoColisionado = collision.gameObject;

        // Realizar acciones adicionales seg�n el objeto con el que colision�.
        if (objetoColisionado.CompareTag("Player"))
        {
            Debug.Log("�Colisi�n con un Player!");
        }
    }
}
