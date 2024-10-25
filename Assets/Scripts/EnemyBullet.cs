using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const int bottomLimit = -15; 

    void Update()
    {
        if(transform.position.y < bottomLimit)
        {
            Destroy(gameObject);   //The bullet will be destroyed when touches the border limit 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enviroment"))
        {
            Destroy(gameObject);
        }
    }
}



