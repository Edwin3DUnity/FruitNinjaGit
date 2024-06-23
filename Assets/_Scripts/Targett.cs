using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Targett : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField, Tooltip("fuerza minima y maxima de salto de los objetivos")]
    private float minForce = 16, maxForce = 18;

    private float maxTorque = 10; // ratación máxima del objetivo

    private float posX = 4; // posición en x para spawnear target

    [SerializeField] float posY = -6;

    private GameManager _gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPos();

        _gameManager = FindObjectOfType<GameManager>();

    }






    /// <summary>
    /// genera un vector 3 aleatorio  en las 3 posiciones
    /// </summary>
    /// <returns></returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }


    /// <summary>
    /// Genera un numero Aleatorio float
    /// </summary>
    /// <returns></returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }



/// <summary>
/// Genera una posición aleatoria en el eje x y posicion fija en y 
/// </summary>
/// <returns></returns>
    private Vector3 RandomPos()
    {
        return new Vector3 (Random.Range(-posX, posX), posY);
    }

// Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Good"))
        {
            _gameManager.GameOver();
            
        }
    }


    private void OnMouseOver()
    {
        if (_gameManager.gameState == GameManager.GameState.inGame)
        {
            Debug.Log("momento de colision con el objeto");
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);
            
            
        }
        
    }
}
