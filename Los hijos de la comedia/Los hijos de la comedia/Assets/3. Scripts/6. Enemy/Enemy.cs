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
    public GameObject manos;
    public float gravityWhileGrabbed = -9.81f; // Ajusta según sea necesario

    public float rotationSpeed = 2.0f; // Ajusta según sea necesario

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
            // Si el jugador está dentro de la distancia especificada para empezar a seguirlo ...
            if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollowPlayer)
            {
                navMeshAgent.speed = 20;
                currentTarget = player.transform.position; // Asigna como objetivo actual al jugador

                // Verifica si ha llegado al jugador
                if (Vector3.Distance(player.transform.position, transform.position) < distanceToPlayerArrival)
                {
                    // Llama a la función que deseas activar cuando llega al jugador
                    LlegoAlJugador();
                }
            }
            else // Si el jugador no está cerca, sigue la rutina de destinos
            {
                // Verifica si ha llegado al destino actual (usando remainingDistance)
                if (navMeshAgent.remainingDistance < 0.1f)
                {
                    navMeshAgent.speed = 15;

                    // Controla cuando alcanza el destino actual
                    if (currentDestination == destinations.Length - 1)
                    {
                        currentDestination = 0; // Vuelve a empezar si es el último destino
                    }
                    else
                    {
                        currentDestination++; // Continúa con el siguiente destino
                    }

                    // Asigna como objetivo actual el destino que le corresponde en la rutina
                    currentTarget = destinations[currentDestination].transform.position;
                }
            }
        }
        else
        {
            // Si ya ha agarrado al jugador, dirígete al destino final
            currentTarget = destinoFinal.transform.position;
            RotateAroundDestinoFinal();

            if (Vector3.Distance(transform.position, destinoFinal.transform.position) < distanceToPlayerArrival)
            {
                // Restaura al jugador a la normalidad y sepáralo de "manos"
                RestorePlayer();
                RestartRoutine();
            }
        }
        navMeshAgent.destination = currentTarget; // Asigna el objetivo al que debe ir, ya sea destino o jugador
    }

    // Función que se llama cuando el enemigo llega al jugador
    void LlegoAlJugador()
    {
        // Aquí puedes poner el código que deseas ejecutar cuando el enemigo llega al jugador
        Debug.Log("El enemigo ha llegado al jugador");
        GrabPlayer();
        hasGrabbedPlayer = true;
    }
    void GrabPlayer()
    {
        // Busca el objeto con tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Si encuentra al jugador
        if (playerObject != null)
        {
            // Si la variable "manos" está asignada
            if (manos != null)
            {
                // Desactiva temporalmente el Character Controller del jugador para modificar la posición
                CharacterController playerController = playerObject.GetComponent<CharacterController>();
                if (playerController != null)
                {
                    playerController.enabled = false;
                }

                // Desactiva la gravedad del jugador
                Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.useGravity = false;
                    playerRigidbody.velocity = Vector3.zero; // Detén cualquier movimiento actual
                    playerRigidbody.angularVelocity = Vector3.zero; // Detén cualquier rotación actual
                }

                // Hace que el objeto "Player" sea hijo del objeto "Manos" del enemigo
                playerObject.transform.parent = manos.transform;

                // Ajusta la posición relativa del "Player" en función de la posición de "Manos"
                playerObject.transform.localPosition = Vector3.zero;

                // Si deseas que el jugador no tenga gravedad mientras está agarrado, ajusta la gravedad
                if (playerRigidbody != null)
                {
                    playerRigidbody.AddForce(Vector3.up * gravityWhileGrabbed, ForceMode.Acceleration);
                }

                Debug.Log("El jugador ha sido agarrado por el enemigo.");
            }
            else
            {
                Debug.LogError("La variable 'manos' no está asignada. Asigna el GameObject 'Manos' desde el inspector.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el tag 'Player'.");
        }
    }

    void RotateAroundDestinoFinal()
    {
        // Calcula la dirección del "destino final" desde la posición actual
        Vector3 directionToDestinoFinal = (destinoFinal.transform.position - transform.position).normalized;

        // Calcula la rotación deseada
        Quaternion lookRotation = Quaternion.LookRotation(directionToDestinoFinal);

        // Aplica la rotación gradual
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void RestorePlayer()
    {
        // Busca el objeto con tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Si encuentra al jugador
        if (playerObject != null)
        {
            // Restaura la jerarquía del jugador
            playerObject.transform.parent = null;

            // Reactiva el Character Controller del jugador
            CharacterController playerController = playerObject.GetComponent<CharacterController>();
            if (playerController != null)
            {
                playerController.enabled = true;
            }

            // Reactiva la gravedad del jugador
            Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.useGravity = true;
            }

            Debug.Log("El jugador ha vuelto a la normalidad y se ha separado del enemigo.");
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el tag 'Player'.");
        }
    }

    void RestartRoutine()
    {
        // Reinicia la rutina
        hasGrabbedPlayer = false;
        currentDestination = 0;
        currentTarget = destinations[currentDestination].transform.position;
        // Puedes agregar cualquier otra lógica de reinicio que necesites aquí
    }
}