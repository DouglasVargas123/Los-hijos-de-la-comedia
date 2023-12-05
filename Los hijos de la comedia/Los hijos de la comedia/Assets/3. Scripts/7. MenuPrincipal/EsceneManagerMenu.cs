using UnityEngine;
using UnityEngine.SceneManagement;
public class EsceneManagerMenu : MonoBehaviour
{
    private string escena = "G.Nivel2";
    // Llama a este método para cargar una escena específica
    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
