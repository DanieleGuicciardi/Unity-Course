using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public GameObject enemyBulletPrefab;  //Prefab 
    public float minFireRate = 10f;  // Tempo minimo tra gli spari iniziale
    public float maxFireRate = 50f;  // Tempo massimo tra gli spari iniziale
    private float fireTimer;  // Timer per tracciare quando sparare
    public float fireRateAcceleration = 0.1f;  // Fattore di accelerazione dello sparo man mano che i nemici muoiono
    private Enemies enemiesManager;  // Riferimento al gestore dei nemici


    void Start()
    {
        fireTimer = Random.Range(minFireRate, maxFireRate);   // Imposta un timer iniziale casuale tra minFireRate e maxFireRate

        enemiesManager = Enemies.I;   // Ottieni il riferimento al gestore dei nemici
    }
    
    void Update()
    {
        // Aggiorna il timer
        fireTimer -= Time.deltaTime;

        // Se il timer è scaduto, spara e resetta il timer
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = Random.Range(minFireRate, maxFireRate);  // Reset con un nuovo intervallo casuale
        }
    }
        // Metodo per sparare proiettili
    private void Shoot()
    {
        // Istanzia il proiettile nemico e fallo sparare verso il basso
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        //Devo aggiungere effetti sonori o effetti
    }

    void OnTriggerEnter2D(Collider2D collider)  // Bullet and enemy destroy logic
    {
        if (collider.gameObject.CompareTag("Bullet"))   // Quando il proiettile tocca il nemico
        {

            
            // Distruggi il proiettile
            Destroy(collider.gameObject);  

            // Distruggi il nemico
            Destroy(gameObject);   
        }
    }

}




