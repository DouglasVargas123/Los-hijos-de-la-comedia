using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finales : MonoBehaviour
{
    private string escenaBuena = "FinalBueno";
    private string escenaMala = "FinalMalo";

    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    private void OnTriggerEnter(Collider jugador)
    {
        // Verifica si el objeto que entró tiene la etiqueta "Player"
        if (jugador.CompareTag("Player"))
        {
            if (ControladorDatos.instance.inBernado && ControladorDatos.instance.inValdivia && ControladorDatos.instance.InVioleta && ControladorDatos.instance.inNegro && ControladorDatos.instance.inBlanco)
            {
                CargarEscena(escenaBuena);
            }
            else
            {
                CargarEscena(escenaMala);
            }
        }
    }
}
