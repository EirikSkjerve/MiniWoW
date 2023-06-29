using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private int maxHitPoints;
    [SerializeField] private int currentHitPoints;
    [SerializeField] private int maxResource;
    [SerializeField] private int currentResource;
    [SerializeField] private int level;
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
        switch (valueHitPoints)
        {
            case > 0 when valueHitPoints <= maxHitPoints && isAlive:
                currentHitPoints = valueHitPoints;
                break;
            case < 0:
                isAlive = false;
                currentHitPoints = 0;
                break;
        }
    }

    public int GetHitPoints()
    {
        return currentHitPoints;
    }

    protected void SetResource(int valueResource)
    {
        if (valueResource >= 0 && valueResource <= maxResource && isAlive)
        {
            currentResource = valueResource;
        }
    }
    
    public int GetResource()
    {
        return currentResource;
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
        if (!isAlive || damage < 0) return;
        
        var current = GetHitPoints();
        var updated = current - damage;
        SetHitPoints(updated > 0 ? updated : 0);
    }

    public void TakeHealing(int healing)
    {
        if (!isAlive || healing <= 0) return;

        var current = GetHitPoints();
        var updated = current + healing;
        SetHitPoints(updated <= maxHitPoints ? updated : maxHitPoints);
    }
    
}
