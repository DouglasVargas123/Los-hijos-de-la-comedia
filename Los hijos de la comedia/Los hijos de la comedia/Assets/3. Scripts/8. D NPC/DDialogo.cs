using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDialogo : MonoBehaviour
{
    [SerializeField] private Animator anim, animpredrodevaldivia;

    // Este método se llama cuando otro Collider entra en el colisionador de este objeto
    private void OnTriggerEnter(Collider asjdhkalskdja)
    {
        // Verifica si el objeto que entró tiene la etiqueta "Player"
        if (asjdhkalskdja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el área
            Debug.Log("LLeog");
            animpredrodevaldivia.SetBool("Hablar", true);
            anim.SetTrigger("Aparece");
        }
    }

    private void OnTriggerExit(Collider asdasdasdjahsdlkja)
    {
        // Verifica si el objeto que entró tiene la etiqueta "Player"
        if (asdasdasdjahsdlkja.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el área
            anim.SetTrigger("Desaparece");
            animpredrodevaldivia.SetBool("Hablar", false);
            Debug.Log("Salio");
        }
    }
}
