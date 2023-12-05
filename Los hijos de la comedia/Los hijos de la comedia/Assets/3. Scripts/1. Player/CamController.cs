using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    [SerializeField] private Transform[] Views;
    [SerializeField] private Transform[] lookAt;
    public Enemy enemy;


    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó el jugador tiene una etiqueta específica
        if (other.gameObject.name == "SalaTerceraPersona" || other.gameObject.name == "Sala (1)" || other.gameObject.name == "Sala (2)" || other.gameObject.name == "Sala (3)" || 
            other.gameObject.name == "Sala (4)" || other.gameObject.name == "Sala (5)" || other.gameObject.name == "Sala (6)" || other.gameObject.name == "Sala (7)" || other.gameObject.name == "Sala (8)" || other.gameObject.name == "Sala (9)"
            || other.gameObject.name == "Sala (10)" || other.gameObject.name == "Sala (11)" || other.gameObject.name == "Sala (12)" || other.gameObject.name == "Sala (13)" || other.gameObject.name == "Sala (14)" || other.gameObject.name == "Sala (15)" || 
            other.gameObject.name == "Sala (16)" || other.gameObject.name == "Sala (17)" || other.gameObject.name == "Sala (18)" || other.gameObject.name == "Sala (19)" || other.gameObject.name == "Sala (20)" || other.gameObject.name == "Sala (21)"
            || other.gameObject.name == "Sala (22)")
        {
            // Realiza alguna acción específica para cada objeto
            if (other.gameObject.name == "SalaTerceraPersona")
            {
                virtualCam.Follow = Views[0];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (1)")
            {
                virtualCam.Follow = Views[1];
                virtualCam.LookAt = lookAt[1];
            }
            else if (other.gameObject.name == "Sala (2)")
            {
                virtualCam.Follow = Views[2];
                virtualCam.LookAt = lookAt[2];
            }
            else if (other.gameObject.name == "Sala (3)")
            {
                virtualCam.Follow = Views[3];
                virtualCam.LookAt = lookAt[3];
            }
            else if (other.gameObject.name == "Sala (4)")
            {
                virtualCam.Follow = Views[4];
                virtualCam.LookAt = lookAt[4];
            }
            else if (other.gameObject.name == "Sala (5)")
            {
                virtualCam.Follow = Views[5];
                virtualCam.LookAt = lookAt[5];
            }
            else if (other.gameObject.name == "Sala (6)")
            {
                virtualCam.Follow = Views[6];
                virtualCam.LookAt = lookAt[6];
            }
            else if (other.gameObject.name == "Sala (7)")
            {
                virtualCam.Follow = Views[7];
                virtualCam.LookAt = lookAt[7];
            }
            else if (other.gameObject.name == "Sala (8)")
            {
                virtualCam.Follow = Views[8];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (9)")
            {
                virtualCam.Follow = Views[9];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (10)")
            {
                virtualCam.Follow = Views[10];
                virtualCam.LookAt = lookAt[0];
                enemy.distanceToFollowPlayer = 0;
            }
            else if (other.gameObject.name == "Sala (11)")
            {
                enemy.distanceToFollowPlayer = 25;
            }
            else if (other.gameObject.name == "Sala (12)")
            {
                virtualCam.Follow = Views[12];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (13)")
            {
                virtualCam.Follow = Views[13];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (14)")
            {
                virtualCam.Follow = Views[14];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (15)")
            {
                virtualCam.Follow = Views[15];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (16)")
            {
                virtualCam.Follow = Views[16];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (17)")
            {
                virtualCam.Follow = Views[17];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (18)")
            {
                virtualCam.Follow = Views[18];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (19)")
            {
                virtualCam.Follow = Views[19];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (20)")
            {
                virtualCam.Follow = Views[20];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (21)")
            {
                virtualCam.Follow = Views[21];
                virtualCam.LookAt = lookAt[0];
            }
            else if (other.gameObject.name == "Sala (22)")
            {
                virtualCam.Follow = Views[22];
                virtualCam.LookAt = lookAt[0];
            }
        }
    }
}
