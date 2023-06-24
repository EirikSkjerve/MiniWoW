using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public Stats playerStats;
    float xdir;
    float ydir;
    // Start is called before the first frame update
    public override void Start()
    {
        playerStats = new Stats();
        playerStats.moveSpeed = 3.1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        Move();
    }

  

    public override void Move()
    {

        
            xdir = 0;
            ydir = 0;

            if (Input.GetKey(KeyCode.W))
            {
                ydir += 1;

            }

            if (Input.GetKey(KeyCode.S))
            {

                ydir -= 1;

            }

            if (Input.GetKey(KeyCode.A))
            {
                xdir -= 1;

            }

            if (Input.GetKey(KeyCode.D))
            {
                xdir += 1;


            }

            body.velocity = new Vector2(xdir,ydir).normalized * playerStats.moveSpeed;
        
    }
}
