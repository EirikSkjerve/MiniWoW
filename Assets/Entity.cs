using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private int hitPoints;
    [SerializeField] private int resource;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool inCombat;
    [SerializeField] private bool isAlive;
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

    protected void SetHitPoints(int valueHitPoints)
    {
        if (valueHitPoints >= 0 && isAlive)
        {
            hitPoints = valueHitPoints;
        }
        
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    protected void SetResource(int valueResource)
    {
        resource = valueResource;
    }
    
    public int GetResource()
    {
        return resource;
    }

    protected void SetRunSpeed(float valueRunSpeed)
    {
        runSpeed = valueRunSpeed;
        walkSpeed = runSpeed / 7;
    }
    
    public float GetRunSpeed()
    {
        return runSpeed;
    }

    protected float GetWalkSpeed()
    {
        return walkSpeed;
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive)
        {
            return;

        }
        var current = GetHitPoints();
        var updated = current - damage;
        if (updated > 0)
        {
            SetHitPoints(updated);
        }
        else
        {
            SetHitPoints(0);
            Debug.Log("Entity has died");
        }
    }
    
}
