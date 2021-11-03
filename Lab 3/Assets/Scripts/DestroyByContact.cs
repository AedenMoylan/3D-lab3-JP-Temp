using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int livesValue;
    private GameController gameController;

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
    }

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
       // Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
              gameController.loseLives(livesValue);
              Destroy(gameObject);
              
             //Instantiate(explosion, transform.position, transform.rotation);

            //gameController.GameOver();
        }
        if (other.tag == "PlayerBullet" )
        {
            if (tag == "EnemyBullet")
            {
                return;
            }
            else
            {
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
                Destroy(other.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
            
        }
        // am adding the power up to the player if this is true
        if (other.tag == "powerUp")
        {
            
            Destroy(other.gameObject);
            Debug.Log("hit power up ");
            
        }

    }
}