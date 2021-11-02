using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    

    public float speed;
    Vector3 movement;
    public Rigidbody rb;
   
    void Start()
    {
        movement = new Vector3(0, 0, 0.02f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += movement * speed;
        rb.rotation = Quaternion.Euler(0.0f, .0f, 2.0f);
    }
}
