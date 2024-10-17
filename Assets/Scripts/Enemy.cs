using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnDestroy()
    {
        // Quando un nemico viene distrutto, chiama il metodo CheckEnemies() nella classe Enemies
        if (Enemies.I != null)
        {
            Enemies.I.CheckEnemies();
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D collider)       //bullet and enemy destroy animation
    {
        
        if (collider.gameObject.CompareTag("Bullet"))   // when the bullet touch the enemy
        {
            Enemies.I.CheckEnemies();
            Destroy(collider.gameObject);  // destroy bullet 
            Destroy(gameObject);   // destroy enemy  
        }
    }

}




