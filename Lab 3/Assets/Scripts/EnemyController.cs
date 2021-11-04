using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceHP()
    {
        HP--;
    }

    public int getHP()
    {
        return HP;
    }





}
