using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    public static Enemies I;  // Static reference to Enemies
    private int rightLimit = 3;
    private int leftLimit = -3;
    private int initialChildCount;  // Numero iniziale di colonne

    void Start()
    {
        if (I == null) I = this;
        else Destroy(gameObject);

        initialChildCount = transform.childCount;  // Salva il numero iniziale di colonne

        StartAnimation();

        // Rinomina le colonne dei nemici
        for (int i = 0; i < transform.childCount; i++)
        {
            var enemyColumn = transform.GetChild(i);
            enemyColumn.name = "EnemyColumn " + i;
        }
    }

    public void CheckEnemies()
    {
        // Scorri tutte le colonne a ritroso, in modo che non ci siano problemi durante la rimozione
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var column = transform.GetChild(i);

            // Se la colonna non ha più nemici, distruggila
            if (column.childCount == 0)
            {
                // Aggiorna i limiti se è la prima o l'ultima colonna
                if (i == 0)
                {
                    leftLimit -= 2;  // Aggiorna il limite sinistro
                }
                else if (i == transform.childCount - 1)
                {
                    rightLimit += 2;  // Aggiorna il limite destro
                }

                // Distruggi la colonna vuota
                Destroy(column.gameObject);
            }
        }
        
        if (transform.childCount == 1 && transform.GetChild(0).childCount == 1)    //la colonna viene distrutta dopo che colpisco un altro nemico quindi mi rimarra sempre una colonna ERRORE?
        {
            Debug.Log("Hai vinto!");
        }        
    }

    private void StartAnimation()
    {
        float accelerationFactor = 0.5f;  // Velocità di accelerazione
        float duration = Mathf.Max(0.5f, 3 - (accelerationFactor * (initialChildCount - transform.childCount)));

        // Aggiungi la sequenza di animazione
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(rightLimit, duration));
        sequence.Append(transform.DOMoveX(leftLimit, duration));
        sequence.OnComplete(StartAnimation);
        sequence.Play();
    }
}




/* Implementazioni:
-aumento della velocita di spostamento dei nemici manmano che vengono distrutti

 */


