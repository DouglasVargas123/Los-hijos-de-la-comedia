using UnityEngine;
using UnityEngine.SceneManagement;
public class EsceneManagerMenu : MonoBehaviour
{
    private string escena = "G.Nivel2";
    // Llama a este m�todo para cargar una escena espec�fica
    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
