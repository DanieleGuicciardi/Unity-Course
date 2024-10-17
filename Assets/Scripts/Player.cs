using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const  int PosY = -13;    //y-axis, player start 
    private const int Speed = 25;   //var speed 
    private const int HorizontalLimit = 14;     //L or R border limit    //cercare modo per fare un float invece di int

    public Bullet BulletPrefab;  //var bullet

    void Start()
    {

    }

    void Update()
    {
        Shoot();

        Move();
    }

    private void Move()
    {
                var horizontalInput = Input.GetAxisRaw("Horizontal");  //x-axis input player. Raw implement constant speed without acceleration  

        var canMoveRight = transform.position.x <= HorizontalLimit;
        var canMoveLeft = transform.position.x >= -HorizontalLimit;

        var isMovingRight = horizontalInput > 0;
        var isMovingLeft = horizontalInput < 0;

        //  Debug.Log("IsMovingRight: " + isMovingRight + "isMovingleft: " + isMovingLeft);   <--- To test implementation use Debug.Log(...)

        if((isMovingRight && canMoveRight) || (isMovingLeft && canMoveLeft))
        {
            transform.position = new Vector2(transform.position.x + horizontalInput * Time.deltaTime * Speed, PosY);  
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);   // Spawn the bullet from the player 
        } 
    }
}





