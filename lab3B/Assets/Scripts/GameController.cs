using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // GaneObject definitions
    public GameObject enemy;
    public GameObject powerUp;
    public GameObject asteroid;
    public GameObject Boss;

    // used to randomly respawn enemy
    public Vector3 spawnValues;


    public int enemyCount;
    public float spawnWait;
    public float startWait;

    // textMestPro definitions
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text restartText;
    public TMP_Text gameOverText;
    public TMP_Text HPText;

    // used for the border
    Vector2 maxPos;
    Vector2 minPos;

    // used to spawn powerUp and Enemy3
    bool attemptToUpgrade = false;
    bool spawnEnemyThree = false;


    private bool restart;
    private int score;

    private PlayerController player;

    void Start()
    {
        // play music
        GetComponent<AudioSource>().Play();
        // used for the border
        minPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        livesText.text = "";
        score = 0;

        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        // sets text and spawns the first wave
        UpdateScore();
        UpdateLives();
        UpdatePlayerHPText();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        // used to restart the game
        if (restart)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        // game over if score passes a certain point
        else if (score>=15)
        {
            GameOver();
            
        }
        // spawns boss based on score
        if(score==6)
        {
            score++;
            StartCoroutine(spawnBoss());
        }

        // spawns upgrade ship
        if(score==3)
        {
            score++;
           
            StartCoroutine(upgradeShip());

           
        }

       
    }

    // instanciates powerup
        IEnumerator upgradeShip()
    {
        yield return new WaitForSeconds(2);
        attemptToUpgrade = true;
        if(attemptToUpgrade == true)
        {
        Instantiate(powerUp);
        attemptToUpgrade = false;
        }
        

    }
    // instanciates boss
    IEnumerator spawnBoss()
    {
        yield return new WaitForSeconds(2);
        spawnEnemyThree = true;
        if (spawnEnemyThree == true)
        {
            Instantiate(Boss);
            spawnEnemyThree = false;
        }

    }
    // spawns waves
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
                
                    
                  spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                  spawnRotation = Quaternion.identity;
                  Instantiate(asteroid, spawnPosition, spawnRotation);
                    
                
                
                yield return new WaitForSeconds(spawnWait);
            }
           
            break;
        }
    }

    
    // adds and calls updateScore()
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    // updates score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    // lowers HP and calls UodatePlayerHPText()
    public void loseHP()
    {
        player.reduceHP();
        UpdatePlayerHPText();
    }

    // updates player HP
    void UpdatePlayerHPText()
    {
        HPText.text = "HP: " + player.getHP();
    }
    // updates player's lives
    void UpdateLives()
    {
        livesText.text = "Lives: " + player.playerLives;
    }
    
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        restart = true;   
    }
    public void loseLives(int newLiveValue)
    {
        player.playerLives += newLiveValue;
        UpdateLives();
    }
    // returns hp to base of every live
    public void resetHP()
    {
        player.returnHPToBase();
        UpdatePlayerHPText();

    }



    
}