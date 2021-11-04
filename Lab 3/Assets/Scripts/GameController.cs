using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
   // public GameObject hazard;
    public GameObject enemy;
    public GameObject powerUp;
    public GameObject asteroid;
    public Vector3 spawnValues;
   // public int hazardCount;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text restartText;
    public TMP_Text gameOverText;
    public TMP_Text HPText;

    
    Vector2 maxPos;
    Vector2 minPos;
    bool attemptToUpgrade = false;
   
    private bool restart;
    private int score;

    private PlayerController player;

    void Start()
    {
        
        GetComponent<AudioSource>().Play();
        minPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        livesText.text = "lives bruh";
       // HPText.text = "";
        score = 0;

        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        UpdateScore();
        UpdateLives();
        UpdatePlayerHPText();
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

        else if (score>=10)
        {
            GameOver();
        }

        // if score is greater than number of enemies i.e they are dead all of them
        // move into the next scene with scene manager
        ///

        if(score==3)
        {
            score++;
           
            StartCoroutine(upgradeShip());

           
        }

       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("power Up Hit Player");
        }
    }

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

    

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void loseHP()
    {
        player.reduceHP();
        UpdatePlayerHPText();
    }

    void UpdatePlayerHPText()
    {
        HPText.text = "HP: " + player.getHP();
    }
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

    public void resetHP()
    {
        player.returnHPToBase();
        UpdatePlayerHPText();

    }

    
}