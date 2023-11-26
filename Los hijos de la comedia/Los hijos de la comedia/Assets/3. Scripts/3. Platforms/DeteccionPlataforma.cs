using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPlataforma : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Realizar acciones específicas cuando hay una colisión física.
        Debug.Log("¡Colisión detectada!");

        // Puedes acceder al objeto con el que colisionó a través de la variable "collision".
        GameObject objetoColisionado = collision.gameObject;

        // Realizar acciones adicionales según el objeto con el que colisionó.
        if (objetoColisionado.CompareTag("Player"))
        {
            Debug.Log("¡Colisión con un Player!");
        }
    }
}
