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



    public int pointvalue;

    public ParticleSystem explosion;


    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);


        transform.position = RandomPos();

        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomForce()
    {

        return Vector3.up * Random.Range(minForce, maxForce); 

    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }


    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-posX, posX), posY);
    }


    private void OnMouseOver()
    {
        if (_gameManager._gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);    
            _gameManager.UpdateScore(pointvalue);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Good"))
        {
            _gameManager.GameOver();
        }
    }
}
