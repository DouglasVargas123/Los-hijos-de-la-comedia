using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDialogo : MonoBehaviour
{
    [SerializeField] private Animator animPanel, animNPC;

    [HideInInspector] public bool inBernado, inBlanco, inNegro,inValdivia, InVioleta;

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
                inBernado = true;
            }
            else if(this.gameObject.name == "PedroDeValdivia")
            {
                AudioManager.instance.VozValdivia();
                inValdivia = true;
            }
            else if (this.gameObject.name == "PerroNegro")
            {
                AudioManager.instance.VozPerroNegro();
                inNegro = true;
            }
            else if (this.gameObject.name == "PerroBlanco")
            {
                AudioManager.instance.VozPerroBlanco();
                inBlanco = true;
            }
            else if (this.gameObject.name == "Violeta_Parra")
            {
                AudioManager.instance.VozPerroBlanco();
                InVioleta = true;
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
            InVioleta = true; inBlanco = true; inNegro = true; inValdivia = true; inBernado = true;
        }
    }
}
