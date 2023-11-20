using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    [SerializeField] private Transform[] Views;


    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó el jugador tiene una etiqueta específica
        if (other.gameObject.name == "SalaTerceraPersona" || other.gameObject.name == "Sala (1)" || other.gameObject.name == "Sala (2)" || other.gameObject.name == "Sala (3)" || other.gameObject.name == "Sala (4)" || other.gameObject.name == "Sala (5)")
        {
            // Realiza alguna acción específica para cada objeto
            if (other.gameObject.name == "SalaTerceraPersona")
            {
                virtualCam.Follow = Views[0];
            }
            else if (other.gameObject.name == "Sala (1)")
            {
                virtualCam.Follow = Views[1];
            }
            else if (other.gameObject.name == "Sala (2)")
            {
                virtualCam.Follow = Views[2];
            }
            else if (other.gameObject.name == "Sala (3)")
            {
                virtualCam.Follow = Views[3];
            }
            else if (other.gameObject.name == "Sala (4)")
            {
                virtualCam.Follow = Views[4];
            }
            else if (other.gameObject.name == "Sala (5)")
            {
                virtualCam.Follow = Views[5];
            }

        }
    }
}
