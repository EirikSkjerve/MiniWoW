using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public Stats PlayerStats;
    [SerializeField] private float xDir;
    [SerializeField] private float yDir;
    // Start is called before the first frame update
    public override void Start()
    {
        PlayerStats = new Stats();
        PlayerStats.MoveSpeed = 3.1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        Move();
    }

  

    public override void Move()
    {

        
            xDir = 0;
            yDir = 0;

            if (Input.GetKey(KeyCode.W))
            {
                yDir += 1;

            }

            if (Input.GetKey(KeyCode.S))
            {

                yDir -= 1;

            }

            if (Input.GetKey(KeyCode.A))
            {
                xDir -= 1;

            }

            if (Input.GetKey(KeyCode.D))
            {
                xDir += 1;


            }

            body.velocity = new Vector2(xDir,yDir).normalized * PlayerStats.MoveSpeed;
        
    }
}
