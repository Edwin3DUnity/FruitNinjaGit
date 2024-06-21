using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{

    private Button _button;

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetDifficulty()
    {
        //Debug.Log("El boton " + gameObject.name + " ha sido pulsado");
        _gameManager.StartGame();
        
    }
}
