using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
   [SerializeField] private GameObject botonPausa;
   [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject botonOpciones;

    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa(); 
            }
        }
    }
    public void Pausa()
    {
        juegoPausado = true;

        Time.timeScale = 0f;
      botonPausa.SetActive(false);
      menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void Opciones()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        menuOpciones.SetActive(true);
        menuPausa.SetActive(false);
       
    }
}
