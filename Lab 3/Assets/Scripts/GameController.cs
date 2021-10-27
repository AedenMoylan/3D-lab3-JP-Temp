using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject enemy;
    public Vector3 spawnValues;
    public int hazardCount;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int playerLives;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text restartText;
    public TMP_Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        livesText.text = "lives bruh";
        score = 0;
        playerLives = 3;
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
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnWaves()
    {
        //yield return new WaitForSeconds(startWait);
        //while (true)
        //{
        //    for (int i = 0; i < hazardCount; i++)
        //    {
        //        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        //        Quaternion spawnRotation = Quaternion.identity;
        //        Instantiate(hazard, spawnPosition, spawnRotation);
        //        yield return new WaitForSeconds(spawnWait);
        //    }
        //    yield return new WaitForSeconds(waveWait);

        //    if (gameOver)
        //    {
        //        restartText.text = "Press 'R' for Restart";
        //        restart = true;
        //        break;
        //    }
        //}
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
        gameOver = true;
    }
    public void loseLives(int newLiveValue)
    {
        playerLives += newLiveValue;
        UpdateLives();
    }
}