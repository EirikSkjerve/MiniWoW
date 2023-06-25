using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    public struct Stats
    {
        public float RunSpeed;
        public float WalkSpeed;
        public int Strength;
        public int Hitpoints;
    }

    public Stats EntityStats;
    // Start is called before the first frame update
    public virtual void Start()
    {
        EntityStats.RunSpeed = 10f;
        EntityStats.WalkSpeed = 3f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Move()
    {
        
    }
    public virtual void WalkTo(Vector2 position)
    {
        body.velocity = position * EntityStats.WalkSpeed;
    }
    
    public virtual void RunTo(Vector2 position)
    {
        body.velocity = position * EntityStats.RunSpeed;
    }
}
