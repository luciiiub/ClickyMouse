using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb; // Componente Rigidbody del objeto
    private GameManager gameManager;  // Referencia al GameManager

    //velocidades
    private float minSpeed = 12f;   
    private float maxSpeed = 16f;  
    private float maxTorque = 2f;     // Maximo torque (torque = vel.rotacion,disminuir para q se vea mejor!!!)

    //rangos posicion
    private float xRange = 4f;                  
    private float ySpawnPos = -2f;              

    public int pointValue;    // Valor de puntos
    public ParticleSystem explosionParticle;  // Particulas al hacer clic

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();    // Obtiene el Rigidbody
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Busca el GameManager

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);   // Aplica una fuerza hacia arriba
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);  // Aplica torque aleatorio
        transform.position = RandomSpawnPos();   // Coloca el objeto en una posicion aleatoria
    }

    private void OnMouseDown()
    {
        // Si el juego esta activo y se hace clic en el objeto
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);   // Destruye el objeto
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);  // Crea particulas
            gameManager.UpdateScore(pointValue);  // Suma los puntos!!
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // El objeto se destruye al tocar el suelo

        // Si NO es un objeto malo (Bad), termina el juego!!
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Fuerza aleatoria hacia arriba
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    //Torque aleatorio
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Posicion aleatoria 
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0f);
    }
}
