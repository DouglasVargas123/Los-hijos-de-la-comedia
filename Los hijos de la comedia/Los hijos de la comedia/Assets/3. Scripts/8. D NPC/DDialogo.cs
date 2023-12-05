using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDialogo : MonoBehaviour
{
    [SerializeField] private Animator animPanel, animNPC;


    // Este método se llama cuando otro Collider entra en el colisionador de este objeto
    private void OnTriggerEnter(Collider asjdhkalskdja)
    {
        // Verifica si el objeto que entró tiene la etiqueta "Player"
        if (asjdhkalskdja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el área
            animNPC.SetBool("Hablar", true);
            animPanel.SetTrigger("Aparece");
            if (this.gameObject.name == "BernadorOhigins")
            {
                AudioManager.instance.VozBernardo();
                ControladorDatos.instance.VerdaderoBernardo();
            }
            else if(this.gameObject.name == "PedroDeValdivia")
            {
                AudioManager.instance.VozValdivia();
                ControladorDatos.instance.VerdaderoValdivia();
            }
            else if (this.gameObject.name == "PerroNegro")
            {
                AudioManager.instance.VozPerroNegro();
                ControladorDatos.instance.VerdaderoNegro();
            }
            else if (this.gameObject.name == "PerroBlanco")
            {
                AudioManager.instance.VozPerroBlanco();
                ControladorDatos.instance.VerdaderoBlanco();
            }
            else if (this.gameObject.name == "Violeta_Parra")
            {
                AudioManager.instance.VozPerroBlanco();
                ControladorDatos.instance.VerdaderoVIoleta();
            }

        }
    }

    private void OnTriggerExit(Collider asdasdasdjahsdlkja)
    {
        // Verifica si el objeto que entró tiene la etiqueta "Player"
        if (asdasdasdjahsdlkja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el área
            animPanel.SetTrigger("Desaparece");
            animNPC.SetBool("Hablar", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
        }
    }
}
