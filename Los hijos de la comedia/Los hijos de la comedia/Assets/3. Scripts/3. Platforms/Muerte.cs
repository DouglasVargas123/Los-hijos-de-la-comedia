using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour
{
    public Vector3 nuevaPosicion;
    public Transform nuevaObjeto1;
    public Transform nuevaObjeto2;
    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Inicia la corutina cuando se detecta al jugador
            StartCoroutine(MoverJugadorCoroutine(other.GetComponent<CharacterController>()));
        }
        if (other.CompareTag("Objeto"))
        {
            StartCoroutine(MoverObjetoCoroutine(other.GetComponent<Transform>()));
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

    IEnumerator MoverObjetoCoroutine(Transform pos)
    {


        // Mueve al jugador a la nueva posición durante 2 segundos
        float elapsedTime = 0f;
        float moveDuration = 0.5f;

        if(pos.transform.name == "Objeto1")
        {
            while (elapsedTime < moveDuration)
            {
                // Interpolación lineal para suavizar el movimiento
                pos.transform.position = Vector3.Lerp(pos.transform.position, nuevaObjeto1.position, elapsedTime / moveDuration);
                pos.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        else if(pos.transform.name == "Objeto2")
        {
            while (elapsedTime < moveDuration)
            {
                // Interpolación lineal para suavizar el movimiento
                pos.transform.position = Vector3.Lerp(pos.transform.position, nuevaObjeto2.position, elapsedTime / moveDuration);
                pos.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }


        // Haz algo adicional si es necesario
        Debug.Log("El Objeto1 ha sido movido a la posición: " + pos.transform.position);
    }
}