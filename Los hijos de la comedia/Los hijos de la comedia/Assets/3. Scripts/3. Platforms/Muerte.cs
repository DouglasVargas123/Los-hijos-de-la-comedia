using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour
{
    public Vector3 nuevaPosicion = new Vector3(0f, 4.25f, -100f);
    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Inicia la corutina cuando se detecta al jugador
            StartCoroutine(MoverJugadorCoroutine(other.GetComponent<CharacterController>()));
        }
    }

    IEnumerator MoverJugadorCoroutine(CharacterController characterController)
    {

        // Desactiva el CharacterController temporalmente
        characterController.enabled = false;

        // Mueve al jugador a la nueva posición durante 2 segundos
        float elapsedTime = 0f;
        float moveDuration = 2f;
        Debug.Log("Toco");
        anim.SetTrigger("Muerto");
        yield return new WaitForSeconds(0.6f);

        while (elapsedTime < moveDuration)
        {
            // Interpolación lineal para suavizar el movimiento
            characterController.transform.position = Vector3.Lerp(
                characterController.transform.position, nuevaPosicion, elapsedTime / moveDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        // Vuelve a activar el CharacterController
        characterController.enabled = true;
        anim.SetTrigger("Vivo");

        // Haz algo adicional si es necesario
        Debug.Log("El jugador ha sido movido a la posición: " + nuevaPosicion);
    }
}