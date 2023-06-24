using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    public struct Stats
    {
        public float moveSpeed;
        public int strength;
        public int hitpoints;
    }

    public Stats entityStats;
    // Start is called before the first frame update
    public virtual void Start()
    {
        entityStats.moveSpeed = 10f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Move()
    {

    }
}
