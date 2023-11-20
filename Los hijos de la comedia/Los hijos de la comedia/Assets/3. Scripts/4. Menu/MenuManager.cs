using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    private Animator anim;
    public EventSystem eventSystem;
    public GameObject[] botones;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SwitchMenu()
    {
        anim.SetTrigger("SwitchMenu");
        eventSystem.firstSelectedGameObject = botones[0]; //Reanudar
    }

    public void SwitchGameplay()
    {
        anim.SetTrigger("SwitchGameplay");
        eventSystem.firstSelectedGameObject = null;
    }

    public void SwitchOptions()
    {
        anim.SetTrigger("SwitchOpciones");
        eventSystem.firstSelectedGameObject = botones[1]; //Controles
    }

    public void SwitchBestiario()
    {
        anim.SetTrigger("SwitchBestiario");
        eventSystem.firstSelectedGameObject = botones[2]; //Volver Bestiario
    }

    public void SwitchGuardarYSalir()
    {
        anim.SetTrigger("SwitchSalir");
        eventSystem.firstSelectedGameObject = botones[3]; //Opcion si
    }

    public void SwitchOpcionesAmenu()
    {
        anim.SetTrigger("SwitchOpcionesAmenu");
    }
    public void SwitchOpcionesAControles()
    {
        anim.SetTrigger("OpcionesAControles");
    }

    public void SwitchControlesAOpciones()
    {
        anim.SetTrigger("SwitchControlesAOpciones");
    }

    public void SwitchOpcionesASonido()
    {
        anim.SetTrigger("SwitchOpcionesASonido");
    }
    public void SwitchBestiarioAOpciones()
    {
        anim.SetTrigger("SwitchBestiarioAOpciones");
    }

    public void SwitchGuardarAOpciones()
    {
        anim.SetTrigger("SwitchGuardarAOpciones");
    }
}
