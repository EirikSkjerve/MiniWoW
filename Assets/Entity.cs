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

    [SerializeField] private Stats EntityStats;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Move()
    {
        
    }
    
}
