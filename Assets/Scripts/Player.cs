using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const  int PosY = -8;

    void Start()
    {
    
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + horizontalInput, PosY);  
        
    }

}
