using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60; // Limita los FPS a 60
                                          // Oculta el cursor al inicio del juego
        //Cursor.visible = false;

        //// Bloquea el cursor en el centro de la pantalla
        //Cursor.lockState = CursorLockMode.Locked;

    }
}
