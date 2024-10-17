using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public GameObject enemyBulletPrefab;  //Prefab 
    public float minFireRate = 10f;  // Tempo minimo tra gli spari iniziale
    public float maxFireRate = 15f;  // Tempo massimo tra gli spari iniziale
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

        // Aggiungi qui altre logiche, come effetti sonori o animazioni se necessario
    }

    void OnTriggerEnter2D(Collider2D collider)  // Bullet and enemy destroy logic
    {
        if (collider.gameObject.CompareTag("Bullet"))   // Quando il proiettile tocca il nemico
        {
            // Notifica al gestore dei nemici
            enemiesManager.CheckEnemies();
            
            // Distruggi il proiettile
            Destroy(collider.gameObject);  

            // Distruggi il nemico
            Destroy(gameObject);   

            // Aumenta il ritmo di fuoco generale man mano che i nemici vengono distrutti
            IncreaseFireRate();
        }
    }

    private void IncreaseFireRate()
    {
        // Riduci il tempo minimo e massimo di fuoco per tutti i nemici
        minFireRate = Mathf.Max(1f, minFireRate - fireRateAcceleration);  // Il minimo rateo non scende sotto 1 secondo
        maxFireRate = Mathf.Max(2f, maxFireRate - fireRateAcceleration);  // Il massimo rateo non scende sotto 2 secondi
    }

}




