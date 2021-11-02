using UnityEngine;
using System.Collections;


public class EvasiveManeuver : MonoBehaviour
{
    public int count;

    public Rigidbody rb;
    public float radius = 2f;
    public float speed;
    public bool offsetIsCenter = true;
    public Vector3 offset;
    Vector3 movement;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //if (offsetIsCenter)
        //{
        //    offset = transform.position;
        //}
        movement = new Vector3(1.0f,1.0f,1.0f);

    }

    void Update()
    {
        count++;
        if (count >= 100)
        {
            changeDirection();
            count = 0;
        }
        //transform.position = new Vector3(
        //            (radius * Mathf.Cos(Time.time * speed)) + offset.x,offset.y,(radius * Mathf.Sin(Time.time * speed)) + offset.z);
        // transform.position = (movement * speed);

        rb.velocity = new Vector3(movement.x * speed, 0.0f, movement.z * speed);
    }
    
    void changeDirection()
    {
        movement.x *= -1;
    }
}
