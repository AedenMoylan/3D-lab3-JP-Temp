using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
   // public GameObject hazard;
    public GameObject enemy;
    public Vector3 spawnValues;
   // public int hazardCount;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int playerLives;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text restartText;
    public TMP_Text gameOverText;
    Vector2 maxPos;
    Vector2 minPos;
    
    private bool restart;
    private int score;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        minPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        livesText.text = "lives bruh";
        score = 0;
       
        UpdateScore();
        UpdateLives();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        
        if (restart)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        if(enemy.transform.position.z <= -1)
        {
            enemy.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        }
        if (playerLives <= 0)
        {
            GameOver();
        }
        else if (score>=10)
        {
            GameOver();
        }
    }

    IEnumerator SpawnWaves()
    {
      
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            break;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + playerLives;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        restart = true;
       
    }
    public void loseLives(int newLiveValue)
    {
        playerLives += newLiveValue;
        UpdateLives();
    }
}