using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    private bool objeto1, objeto2;
    public Animator anim;
    private string escena = "D Nivel2";
    private bool corrutinaEjecutada = false; // Variable para controlar si la corrutina ya se ejecutó

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            if (other.gameObject.name == "Objeto1")
            {
                objeto1 = true;
            }
            else if (other.gameObject.name == "Objeto2")
            {
                objeto2 = true;
            }
            Debug.Log("objeto llego");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Objeto1")
        {
            objeto1 = false;
        }
        else if (other.gameObject.name == "Objeto2")
        {
            objeto2 = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            objeto1 = true;
            objeto2 = true;
        }

        if (objeto1 && objeto2 && !corrutinaEjecutada)
        {
            corrutinaEjecutada = true; // Marcar que la corrutina se ha ejecutado
            StartCoroutine(SegundoNivel());
        }
    }

    private IEnumerator SegundoNivel()
    {
        anim.SetTrigger("Avanzar");
        yield return new WaitForSeconds(5);
        CargarEscena(escena);
    }

    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}