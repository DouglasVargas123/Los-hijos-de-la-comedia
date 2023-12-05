using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDatos : MonoBehaviour
{
    public static ControladorDatos instance;

   [HideInInspector] public bool inBernado, inBlanco, inNegro, inValdivia, InVioleta;

    private void Awake()
    {
        if(ControladorDatos.instance == null)
        {
            ControladorDatos.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inBernado = true; inBlanco = true; inNegro = true; inValdivia = true; InVioleta = true;
            Debug.Log("FinalBUeno");
        }
        if(inBernado == false)
        {
            Debug.Log("finalmanlo");
        }
    }

    public void VerdaderoBernardo()
    {
        inBernado = true;
    }
    public void VerdaderoBlanco()
    {
        inBlanco = true;
    }
    public void VerdaderoNegro()
    {
        inNegro = true;
    }
    public void VerdaderoValdivia()
    {
        inValdivia = true;
    }
    public void VerdaderoVIoleta()
    {
        InVioleta = true;
    }
}
