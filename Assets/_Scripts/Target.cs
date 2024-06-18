using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    
    private float minForce = 12, maxForce = 16;

    
    private float maxTorque = 10;

    
    private float posX =4 ;

    
    private float posY = -6;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos() ;
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
    
}
