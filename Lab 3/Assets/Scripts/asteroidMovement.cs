using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
   

    public Rigidbody rb;
    public float radius = 2f;
    public float speed;
    public bool offsetIsCenter = true;
    public Vector3 offset;
    Vector3 movement;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
        movement = new Vector3(0.0f, 0.0f, -1.0f);
        rb.velocity = movement;
        

    }

    void Update()
    {


        //transform.position = new Vector3(
        //            (radius * Mathf.Cos(Time.time * speed)) + offset.x, offset.y, (radius * Mathf.Sin(Time.time * speed)) + offset.z);
        //transform.position = (movement * speed);



    }

    
}
