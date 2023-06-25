using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    public struct Stats
    {
        public float MoveSpeed;
        public int Strength;
        public int Hitpoints;
    }

    public Stats EntityStats;
    // Start is called before the first frame update
    public virtual void Start()
    {
        EntityStats.MoveSpeed = 10f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Move()
    {
        
    }
    public virtual void MoveTo(Vector2 position)
    {
    
    }
}
