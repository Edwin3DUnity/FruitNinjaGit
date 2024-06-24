using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Objetivos : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField] private float minForce = 16;
    [SerializeField] private float maxForce = 18;

    [SerializeField] private float torqueRotation = 10;

    private float posX = 4;
    [SerializeField, Range(-10 , 0)] private float posY = -4;

    //private GameManager _gameManagr;
    public int pointValue;

    public ParticleSystem explosionParticle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Genera una fuerza aleatoria hacia arriba 
    /// </summary>
    /// <returns> Vector 3 aleatorio de fuerza hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }


    /// <summary>
    /// Genera una rotación utilizando las físicas 
    /// </summary>
    /// <returns> un valor aleatorio entre - torqueratation y torquerotation</returns>
    private float RandomTorque()
    {
        return  Random.Range(-torqueRotation, torqueRotation);
        
    }
    
    /// <summary>
    /// Genera una posición aleatoria en el eje X y una posición fija en el eje Y
    /// </summary>
    /// <returns> vector 3 en tres dimenciones con el eje Y en  fijo</returns>
    private Vector3 posRandom()
    {
        return new Vector3 (Random.Range(-posX, posX),posY);
    }


    private void OnMouseOver()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            
            
        }
    }
}
