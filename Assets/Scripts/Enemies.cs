using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    public static Enemies I;  // Static reference to Enemies
    private int rightLimit = 3;
    private int leftLimit = -3;
    private int initialChildCount;  // initial num of column

    void Start()
    {
        if (I == null) I = this;
        else Destroy(gameObject);

        initialChildCount = transform.childCount;  // save the num of column

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
        for (int i = transform.childCount - 1; i >= 0; i--)
        { 
            var column = transform.GetChild(i);

            
            if (column.childCount == 0)   // when the column has no enemy, destroy it
            {
            
                if (i == 0)  //refresh the limit border
                {
                    leftLimit -= 2; 
                }
                else if (i == transform.childCount - 1)
                {
                    rightLimit += 2; 
                }

                
                Destroy(column.gameObject);
            }
        }
        
        if (transform.childCount == 1 && transform.GetChild(0).childCount == 1)    
        {
            Debug.Log("YOU WIN!!");
        }        
    }

    private void StartAnimation()
    {
        float accelerationFactor = 0.5f;  // Acceleration x death enemy
        float duration = Mathf.Max(0.5f, 3 - (accelerationFactor * (initialChildCount - transform.childCount)));

        
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(rightLimit, duration));
        sequence.Append(transform.DOMoveX(leftLimit, duration));
        sequence.OnComplete(StartAnimation);
        sequence.Play();
    }
}




/* Implementazioni da fare:
-Delle animazioni di distruzione
-Dei suoni?
-Menu di start 
-Game over o Win full screen
-Aggiungere la navicella rossa che passa ogni tanto
-Aggiungere un punteggio
 */


