using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int livesValue;
    private GameController gameController;
    private PlayerController player;
    private EnemyController enemy;
    private EnemyThree enemyThree;

    void Start()
    {
        scoreValue = 1;
        livesValue = -1;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        GameObject enemyObject = GameObject.FindWithTag("Enemy");
        enemy = GetComponent<EnemyController>();


        GameObject enemy3Object = GameObject.FindWithTag("Enemy3");
        enemyThree = GetComponent<EnemyThree>();

    }
    // handles collisions and function calls of the GameObjects
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            return;
        }
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
            if (player.isLifeLost == false)
            {
                if (player.getHP() <= 1)
                {
                    gameController.loseLives(livesValue);
                    gameController.resetHP();
                    player.isLifeLost = true;
                }
                else
                {
                    gameController.loseHP();
                }
            }
            if (player.getLives() <= 0)
            {
                gameController.GameOver();
                Instantiate(playerExplosion, transform.position, transform.rotation);
            }
        }
        if (other.tag == "PlayerBullet" )
        {
            
            if (tag == "EnemyBullet")
            {
                return;
            }
            else
            {
                //if (enemy.getHP() <= 0)
                //{
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
                Destroy(other.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                //}
                //else
                //{
                //    Destroy(other.gameObject);
                //    enemy.reduceHP();
                //}
            }
            
        }

        if (other.tag == "powerUp")
        {
            if (tag == "Player")
            {
                player.isPlayerPoweredUp = true;
                Destroy(other.gameObject);
            }
            else
            {
                return;
            }

        }

        if (other.tag == "Enemy3")
        {
            if (tag == "PlayerBullet")
            {
                enemyThree.loseHP();
                Debug.Log("enemy 3 losing hp");
            }
        }


    }
}