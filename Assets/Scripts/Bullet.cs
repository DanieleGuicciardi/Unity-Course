using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int VerticalLimit = 10;   //Top border limit 


    void Update()
    {
        if(transform.position.y > VerticalLimit)
        {
            Destroy(gameObject);   //The bullet will be destroyed when touches the border limit 
        }
    }
}
