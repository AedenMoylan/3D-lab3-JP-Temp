using UnityEngine;
using System.Collections;



public class EvasiveManeuver : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 1f;
    public bool offsetIsCenter = true;
    public Vector3 offset;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    void Update()
    {
        transform.position = new Vector3(
                    (radius * Mathf.Cos(Time.time * speed)) + offset.x,offset.y,(radius * Mathf.Sin(Time.time * speed)) + offset.z);
    }
}
