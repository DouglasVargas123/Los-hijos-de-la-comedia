using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public Animator anim;
    private string escena = "D Nivel1";
    // Llama a este método para cargar una escena específica
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Secuencia());
    }


    private IEnumerator Secuencia()
    {
        anim.SetTrigger("Intro");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("1");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("2");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("3");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("4");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("5");
        yield return new WaitForSeconds(5);
        anim.SetTrigger("Outro");
        yield return new WaitForSeconds(5);
        CargarEscena(escena);
    }


    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
