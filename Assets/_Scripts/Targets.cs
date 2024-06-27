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

    public ParticleSystem explotion;

    private GameManager _gameManager;

    public int pointvalue;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosx();

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

    private Vector3 RandomPosx()
    {
        return new Vector3(Random.Range(-posX, posX), posY);
    }


    private void OnMouseOver()
    {
        Destroy(gameObject);
        Instantiate(explotion, transform.position, explotion.transform.rotation);
        _gameManager.UpdateScore(pointvalue);
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
