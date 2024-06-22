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


    
    
    // Start is called before the first frame update
    void Start()
    {
       /* gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);*/
        
        //restarButton.onClick.AddListener(RestartGame);
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

    public void GameOver()
    {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
        restarButton.gameObject.SetActive(true);
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
        
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false); 
    }
   
}
