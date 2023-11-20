using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject[] destinations;
    public GameObject destinoFinal;
    public float distanceToFollowPlayer = 5f;
    public float distanceToPlayerArrival = 1.0f;
    private Vector3 currentTarget;
    private int currentDestination = 0;

    [Header("Controlador Jugador")]
    public MovementController movementController;
    public Transform raycastPoint;
    public float rayDistance;

    private bool hasGrabbedPlayer = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentTarget = destinations[currentDestination].transform.position;
    }

    void Update()
    {
        if (!hasGrabbedPlayer)
        {
            // Si el jugador est� dentro de la distancia especificada para empezar a seguirlo ...
            if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollowPlayer)
            {
                navMeshAgent.speed = 10;
                currentTarget = player.transform.position; // Asigna como objetivo actual al jugador

                // Verifica si ha llegado al jugador
                if (Vector3.Distance(player.transform.position, transform.position) < distanceToPlayerArrival)
                {
                    // Llama a la funci�n que deseas activar cuando llega al jugador
                    LlegoAlJugador();
                }
            }
            else // Si el jugador no est� cerca, sigue la rutina de destinos
            {
                if (Vector3.Distance(destinations[currentDestination].transform.position, transform.position) < 0.1f)
                {
                    navMeshAgent.speed = 3;
                    // Controla cuando alcanza el destino actual
                    if (currentDestination == destinations.Length - 1)
                    {
                        currentDestination = 0; // Vuelve a empezar si es el �ltimo destino
                    }
                    else
                    {
                        currentDestination++; // Contin�a con el siguiente destino
                    }
                }
                // Asigna como objetivo actual el destino que le corresponde en la rutina
                currentTarget = destinations[currentDestination].transform.position;
            }
        }
        else
        {
            // Si ya ha agarrado al jugador, dir�gete al destino final
            currentTarget = destinoFinal.transform.position;
        }

        navMeshAgent.destination = currentTarget; // Asigna el objetivo al que debe ir, ya sea destino o jugador
    }

    // Funci�n que se llama cuando el enemigo llega al jugador
    void LlegoAlJugador()
    {
        // Aqu� puedes poner el c�digo que deseas ejecutar cuando el enemigo llega al jugador
        Debug.Log("El enemigo ha llegado al jugador");
        hasGrabbedPlayer = true;
    }
}