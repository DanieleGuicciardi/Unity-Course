using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    public static Enemies I;     //static variabile. Refere to Enemies with I

    private int rightLimit  = 10;
    private int leftLimit = -10;

    void Start()
    {
        if (I == null) I = this;
        else Destroy(gameObject);

        StartAnimation();

        for(int i = 0; i < transform.childCount; i++)
        {
            var enemyColumn = transform.GetChild(i);
            enemyColumn.name = "EnemyColumn " + i;
        }
    }

    public void CheckEnemies()
    {
        if(transform.GetChild(0).childCount == 0)   //increase limit when a column is destroyed
        {
            leftLimit -= 2;
            Destroy(transform.GetChild(0).gameObject);
        }

        var lastChildIndex = transform.childCount - 1;
        if(transform.GetChild(lastChildIndex).childCount == 0)   
        {
            rightLimit += 2;
            Destroy(transform.GetChild(lastChildIndex).gameObject);
        }
    }

    private void StartAnimation()               //enemies moving animation
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(rightLimit, 3));
        sequence.Append(transform.DOMoveX(leftLimit, 3));
        sequence.OnComplete(StartAnimation);
        sequence.Play();    
    }
}




