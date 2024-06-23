using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyGame : MonoBehaviour
{
    private Button _Button;
    private GameManager _gameManager;

    [Range(1, 3)] public int dificulty;
    
    // Start is called before the first frame update
    void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(SetDifficulty);
        _gameManager = FindObjectOfType<GameManager>();
        


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(dificulty);

    }
}



 