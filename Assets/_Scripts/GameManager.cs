using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
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

    private  int score
    {
        set
        {
          /*  _score = value;
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
       /* gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);*/
        
        //restarButton.onClick.AddListener(RestartGame);
        
        ShowMaxScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        
       /* while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
            
            

        }*/
       
        
       while (gameState == GameState.inGame)
       {
           yield return new WaitForSeconds(spawnRate);
           int index = Random.Range(0, targetPrefabs.Count);
           Instantiate(targetPrefabs[index]);
            
            

       } 
    }
    /// <summary>
    /// Actualiza la puntuación y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd"> Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score  \n " + score;


    }


    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if(score > maxScore)
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
        
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restarButton.gameObject.SetActive(true);
        }
        
        
    }

    
   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
/// <summary>
/// Método que inicia la partida cambiando el valor del estado del juego
/// </summary>
/// <param name="difficulty">Número entero que indica el grado de dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
        numberOfLives -= difficulty ;

      /*  for (int i = numberOfLives ; i < lives.Count; i++)
        {
            lives[i].SetActive(false);
            
        }*/

      for (int i = 0; i < numberOfLives; i++)
      {
          lives[i].SetActive(true);
      }
      
        
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false); 
    }
   
    public void ShowMaxScore()
    {
        int maxCore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score: \n" + maxCore;
    }

}
