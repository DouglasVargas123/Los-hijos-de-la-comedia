using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDialogo : MonoBehaviour
{
    [SerializeField] private Animator animPanel, animNPC;

    // Este m�todo se llama cuando otro Collider entra en el colisionador de este objeto
    private void OnTriggerEnter(Collider asjdhkalskdja)
    {
        // Verifica si el objeto que entr� tiene la etiqueta "Player"
        if (asjdhkalskdja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el �rea
            animNPC.SetBool("Hablar", true);
            animPanel.SetTrigger("Aparece");
        }
    }

    private void OnTriggerExit(Collider asdasdasdjahsdlkja)
    {
        // Verifica si el objeto que entr� tiene la etiqueta "Player"
        if (asdasdasdjahsdlkja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el �rea
            animPanel.SetTrigger("Desaparece");
            animNPC.SetBool("Hablar", false);
        }
    }
}
