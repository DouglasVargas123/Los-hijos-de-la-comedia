using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    private string escena = "MainMenu";
    // Llama a este método para cargar una escena específica
    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CargarEscena(escena);
        }
    }
}
