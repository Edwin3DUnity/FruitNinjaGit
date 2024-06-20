using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

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
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
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
    /// <summary>
    /// Actualiza la puntuación y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd"> Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score  \n " + score;


    }
    
}
