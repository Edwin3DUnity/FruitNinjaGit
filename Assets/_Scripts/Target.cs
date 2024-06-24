using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float minFore = 16;
    [SerializeField] private float maxForce = 18;

    private float maxTorque = 10;

    private float posX = 4;
    private float posY = -4;


    public int pointvalue;

    private GameManager _gameManager;

    public ParticleSystem explosionParticle;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandonTorque(), RandonTorque(), RandonTorque(), ForceMode.Impulse);

        transform.position = RandomSpawpnPos();
        _gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Genera un vector aleatorio en 3 dimensiones
    /// </summary>
    /// <returns>Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minFore, maxForce); 
    }


    /// <summary>
    /// Genera  un número aleatorio
    /// </summary>
    /// <returns>Valor aleatorio - maxTorque y maxTorque</returns>
    private float RandonTorque()
    {
        return Random.Range(-maxForce, maxTorque);
    }
    
    /// <summary>
    /// Genera posición aleatoria
    /// </summary>
    /// <returns>Posición en 3 dimensiones, en Z es 0 </returns>
    private Vector3 RandomSpawpnPos()
    {
        return new Vector3(Random.Range(-posX, posX), posY);
    }


    private void OnMouseOver()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        _gameManager.UpdateScore(pointvalue);

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
}
