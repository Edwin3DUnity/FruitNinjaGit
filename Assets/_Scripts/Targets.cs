using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Targets : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float minForce = 16;
    [SerializeField] private float maxForce = 18;
    
    [SerializeField] private float maxTorque = 10;
    
    [SerializeField] private float posX = 4;
    [SerializeField] private float posY = -4;

    public int pointValue;

    public ParticleSystem explosionParticle;

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomPos();

        _gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    /// <summary>
    /// Genera un número aleatorio para la fuerza hacia arriba
    /// </summary>
    /// <returns>Vector 3 entre minima fuerza y máxima fuerza</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce,maxForce); 
    }

    /// <summary>
    /// Genera un valor aleatorio para la rotación utilizando el torque
    /// </summary>
    /// <returns>Un valor aleatorio entre -maxtorque y maxtorque</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    /// <summary>
    /// Genera una posición Aleatorio
    /// </summary>
    /// <returns>Vector 3 para una posición aleatoria en eje X y fija en el eje Y</returns>
    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-posX, posX),posY);
    }


    private void OnMouseOver()
    {
        if (_gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Good"))
        {
            _gameManager.GameOver();
        }
    }
}
