using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0;
    private int randomDirection = 1;
    public float timeRemaining;
    public int HP;

    private PlayerController playerController;
 

    // Start is called before the first frame update
    void Start()
    {
        
        transform.Rotate(new Vector3(0, 180, 0));
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0)
        {
            randomDirection = Random.Range(1, 5);
            timeRemaining = 0.5f;
        }

       

    }

    private void FixedUpdate()
    {
        // moves enemy along a random path
        if (randomDirection == 1)
        {
            rb.velocity = new Vector3(0, 0, transform.forward.z * -speed);
        }
        else if (randomDirection == 2)
        {
            rb.velocity = new Vector3(0, 0, transform.forward.z * speed);

        }
        else if (randomDirection == 3)
        {
            rb.velocity = new Vector3(transform.right.x * speed, 0, 0);

        }
        else if (randomDirection == 4)
        {
            rb.velocity = new Vector3(transform.right.x * -speed, 0, 0);

        }
        // keeps enemy in border
        if (transform.position.z > 12)
        {
            randomDirection = 1;
        }
        if (transform.position.z < -3.5)
        {
            randomDirection = 2;
        }
        if (transform.position.x < -6.5)
        {
            randomDirection = 3;
        }
        if (transform.position.x > 6.5)
        {
            randomDirection = 4;
        }

    }

    public void loseHP()
    {
        HP--;
    }

   
}
