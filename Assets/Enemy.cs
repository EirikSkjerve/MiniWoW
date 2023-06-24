using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Entity
{
    public Stats enemyStats;
    public bool engaged;
    public float counter;
    public Vector2 startPosition;
    // Start is called before the first frame update
    public override void Start()
    {
        enemyStats.moveSpeed = 2;
        engaged = false;
        counter = 0;
        startPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!engaged)
        {
            if (counter > 5)
            {
                counter = 0;
                Wander();
            }
            else
            {
                counter += Time.deltaTime;
            }

            if (new Vector2(startPosition.x - transform.position.x,startPosition.y - transform.position.y).magnitude > 6)
            {
                MoveTo(startPosition);

            }
        }
    }
    void MoveTo(Vector2 target)
    {
        body.velocity = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }
    void Wander()
    {

        float randX = Random.Range(-10, 10);
        float randY = Random.Range(-10, 10);
        body.velocity = new Vector2(randX, randY).normalized * enemyStats.moveSpeed;

    }

    void Chase(Rigidbody2D target)
    {

    }
}
