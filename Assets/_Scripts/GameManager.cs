using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum  GameState
    {
        loading,
        inGame,
        paused,
        GameOver
        
    }

    public GameState _gameState;


    public float spawnRate = 1;

    public List<GameObject> targets;


    public TextMeshProUGUI scoreText;

    private int _score;

    private int score
    {
        set
        {
            _score = Mathf.Max(value, 0);
            
        }
        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private const string MAX_SCORE = "MAX_SCORE";

    private int numberOfLives = 4;
    public List<GameObject> lives;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMaxScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
    
        }
        
    }

    public void UpdateScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = "Score \n " + score;

    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, score);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }
    }

    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >= 0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }

        if (numberOfLives <= 0)
        {
            SetMaxScore();

            _gameState = GameState.GameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        _gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
        numberOfLives -= difficulty;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }


        StartCoroutine(SpawnTargets());

        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);

    }


    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score: \n " + maxScore;

    }
}
