using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
   

    public Rigidbody rb;
    public float radius = 2f;
  
    public bool offsetIsCenter = true;
    public Vector3 offset;
    Vector3 movement;
    float verticalSpeed = 0.5f;
    float angularSpeed = 0.9f;
    float timeCounter=0;
    float circleRad = 3.4f;
    Vector3 center;
    float z;
    float y;
    float x;

    private void Awake()
    {
        center = transform.position;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movement = new Vector3(0.0f, 0.0f, -1.0f);
        rb.velocity = movement;


    }

    void Update()
    {
        timeCounter += angularSpeed * Time.deltaTime;
        z = Mathf.Cos(timeCounter) * circleRad;
        x = Mathf.Sin(timeCounter) * circleRad;
        y = 0;

        transform.position = center + new Vector3(x, y, z);
        center -= new Vector3(0, 0, verticalSpeed * Time.deltaTime);






    }

    
}
