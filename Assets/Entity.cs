using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private int hitPoints;
    [SerializeField] private int resource;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    public struct Stats
    {
        public int Strength;
        public int Intellect;
        public int Agility;
        public int Stamina;
        
    }

    private Stats _entityStats;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void SetHitPoints(int valueHitPoints)
    {
        hitPoints = valueHitPoints;
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
    
    public void SetResource(int valueResource)
    {
        resource = valueResource;
    }
    
    public int GetResource()
    {
        return resource;
    }
    
    public void SetRunSpeed(float valueRunSpeed)
    {
        runSpeed = valueRunSpeed;
        walkSpeed = runSpeed / 7;
    }
    
    public float GetRunSpeed()
    {
        return runSpeed;
    }
    
    public float GetWalkSpeed()
    {
        return walkSpeed;
    }
    
}
