using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        loading,
        paused,
        inGame,
        gameOver
        
    }

    public GameState gameState;


    public List<GameObject> targetPrefabs;
    public float spawnRate = 1;

    public TextMeshProUGUI scoreText;

    private int _score;

    private int score
    {
        set
        {
            /*_score = value;
            if (_score < 0)
            {
                _score = 0;
            }*/

            _score = Mathf.Max(value, 0);

        }

        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;
    public Button restarButton;

    public GameObject titleScreen;


    private const string MAX_SCORE = "MAX_SCORE";



    private int numberOfLives = 4;
    public List<GameObject> lives;
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.inGame;
        StartCoroutine("SpawnTarget");

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
        
        
    }


    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
    }
}
