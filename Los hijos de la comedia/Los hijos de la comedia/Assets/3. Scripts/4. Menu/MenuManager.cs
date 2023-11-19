using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SwitchMenu()
    {
        anim.SetTrigger("SwitchMenu");
    }

    public void SwitchGameplay()
    {
        anim.SetTrigger("SwitchGameplay");
    }

    public void SwitchOptions()
    {
        anim.SetTrigger("SwitchOpciones");
    }

    public void SwitchBestiario()
    {
        anim.SetTrigger("SwitchBestiario");
    }

    public void SwitchGuardarYSalir()
    {
        anim.SetTrigger("SwitchSalir");
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
}
