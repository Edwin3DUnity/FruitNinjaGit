using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    
  [SerializeField]  private float minForce = 16, maxForce = 18;

    
    private float maxTorque = 10;

    
    private float posX =4 ;

    
    private float posY = -6;


    private GameManager _gameManager;


     public int pointValue;

     public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos() ;

        _gameManager = FindObjectOfType<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Genera un vector aleatorio en 3 dimensiones
    /// </summary>
    /// <returns> Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up *  Random.Range(minForce, maxForce);

    }

    /// <summary>
    /// Genera un numero aleatorio
    /// </summary>
    /// <returns>Valor aleatorio entre  - maxTorque y maxTorque</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    /// <summary>
    /// Genera posicion aleatoria
    /// </summary>
    /// <returns>Posicion en 3 dimensiones, z en 0</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-posX, posX), posY);

    }


    private void OnMouseOver()
    {
        if (_gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);  
        }
        

       /* if (gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }*/
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);

           /* if (pointValue > 0)
            {
                _gameManager.UpdateScore(-10);
            }*/
            
            if (gameObject.CompareTag("Good"))
            {
                _gameManager.GameOver();
            }
            
        }
    }
}
