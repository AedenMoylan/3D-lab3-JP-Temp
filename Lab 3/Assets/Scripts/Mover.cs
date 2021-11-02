using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
    bool isEnemyMovingDown;
    bool isEnemyMovingLeft;
    bool isEnemyMovingRight;
	int count;

	void Start ()
	{
		count = 0;
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
        isEnemyMovingDown = true;
        isEnemyMovingLeft = false;
        isEnemyMovingRight = false;

	}

    //void update()
    //   {
    //	count++;
    //	Debug.Log(count);
    //	if(count >= 100)
    //       {
    //		changeDirection();
    //		count = 0;
    //	}
    //   }

    private void FixedUpdate()
    {
        count++;
       // Debug.Log(count);
        if (count >= 50)
        {
            changeDirection();
            count = 0;
        }
    }

    void changeDirection()
    {
        if (isEnemyMovingLeft == true || isEnemyMovingRight == true)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            isEnemyMovingRight = false;
            isEnemyMovingLeft = false;
            isEnemyMovingDown = true;
        }
        else
        {
            int randNum = Random.Range(1, 3);
            Debug.Log(randNum);
            if (randNum == 1)
            {
                GetComponent<Rigidbody>().velocity = transform.right * speed;
                isEnemyMovingRight = true;
                isEnemyMovingDown = false;
            }
        
            else if (randNum == 2)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
                isEnemyMovingLeft = true;
                isEnemyMovingDown = false;
        }
        }
    }
}
