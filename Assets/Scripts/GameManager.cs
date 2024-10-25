using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Player player;

    void Start()
    {   
        gameOverPanel.SetActive(false);    
    }
    
    public void GameOver()
    {
        GameOverPanel.SetActive(true);     //attiva il pannello con la scritta gameover
        Time.timeScale = 0;    //ferma il tempo
    }





}
