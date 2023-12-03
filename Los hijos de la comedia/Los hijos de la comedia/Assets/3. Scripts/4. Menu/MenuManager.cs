using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    private Animator anim;
    public EventSystem eventSystem;
    public GameObject[] botones;
    //0 Reanudar
    //1 Controles
    //2 Volver Bestiario
    //3 Volver Controles
    //4 Volver Sonido
    //5 Si, de guardar y salir

    private void Start()
    {
        anim = GetComponent<Animator>();
        DesactivarMouse();
    }


    //Menu
    public void SwitchMenu()
    {
        anim.SetTrigger("SwitchMenu"); //1
        ActivarMouse();

    }

    public void SwitchMenuFirstSelected()
    {
        eventSystem.firstSelectedGameObject = botones[0]; //Reanudar //2
        eventSystem.SetSelectedGameObject(botones[0]);
    }

    //UI Gameplay
    public void SwitchGameplay()
    {
        anim.SetTrigger("SwitchGameplay");//1 (solo 1)
        DesactivarMouse();
    }

    //UI Opciones
    public void SwitchOptions()
    {
        anim.SetTrigger("SwitchOpciones"); //1
        ActivarMouse();
    }

    public void SwitchOptionsSelected()
    {
        eventSystem.firstSelectedGameObject = botones[1]; //Controles //2
        SelectGameObject(botones[1]);
    }

    //UI Bestiario
    public void SwitchBestiario()
    {
        anim.SetTrigger("SwitchBestiario"); //1
        ActivarMouse();
    }

    public void SwitchBestiarioSelected()
    {
        eventSystem.firstSelectedGameObject = botones[2]; //Volver Bestiario //2
        SelectGameObject(botones[2]);
    }

    //UI Guardar y salir
    public void SwitchGuardarYSalir()
    {
        anim.SetTrigger("SwitchSalir"); //1
        ActivarMouse();
    }

    public void SwitchGuardarYSalirSelected()
    {
        eventSystem.firstSelectedGameObject = botones[5]; //2
        SelectGameObject(botones[5]); //Boton Si
    }

    //UI Menu inicio
    public void SwitchOpcionesAmenu()
    {
        anim.SetTrigger("SwitchOpcionesAmenu"); //1
        ActivarMouse();
    }

    public void SwitchOpcionesAmenuSelected()
    {
        eventSystem.firstSelectedGameObject = botones[0]; //2
        SelectGameObject(botones[0]); //Boton de menu
    }

    //UI A controles
    public void SwitchOpcionesAControles()
    {
        anim.SetTrigger("OpcionesAControles"); //1
        ActivarMouse();
    }

    public void SwitchOpcionesAControlesSelected()
    {
        eventSystem.firstSelectedGameObject = botones[3]; //2
        SelectGameObject(botones[3]); //Boton Si
    }

    //
    public void SwitchControlesAOpciones()
    {
        anim.SetTrigger("SwitchControlesAOpciones"); //1
        ActivarMouse();
    }

    public void SwitchControlesAOpcionesSelected()
    {
        eventSystem.firstSelectedGameObject = botones[1]; //Reanudar //2
        eventSystem.SetSelectedGameObject(botones[1]);
    }

    public void SwitchOpcionesASonido()
    {
        anim.SetTrigger("SwitchOpcionesASonido");
        ActivarMouse();
    }

    public void SwitchOpcionesASonidoSelected()
    {
        //Aca falta la opcion del conido que seria el primero
        eventSystem.firstSelectedGameObject = botones[4]; //Reanudar //2
        eventSystem.SetSelectedGameObject(botones[4]);
    }
    public void SwitchBestiarioAOpciones()
    {
        anim.SetTrigger("SwitchBestiarioAOpciones");
        ActivarMouse();
    }

    public void SwitchBestiarioAOpcionesSelected()
    {
        eventSystem.firstSelectedGameObject = botones[0]; //Reanudar //2
        eventSystem.SetSelectedGameObject(botones[0]);
    }

    public void SwitchGuardarAOpciones()
    {
        anim.SetTrigger("SwitchGuardarAOpciones");
        ActivarMouse();
    }

    public void SwitchGuardarAOpcionesSelected()
    {
        eventSystem.firstSelectedGameObject = botones[0]; //Reanudar //2
        eventSystem.SetSelectedGameObject(botones[0]);
    }


    void SelectGameObject(GameObject obj)
    {
        // Asegúrate de que el EventSystem esté presente en la escena
        if (EventSystem.current != null)
        {
            // Establece el objeto como seleccionado
            EventSystem.current.SetSelectedGameObject(obj);

            // Puedes realizar acciones adicionales después de seleccionar el objeto si es necesario
        }
    }

    private void ActivarMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DesactivarMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
