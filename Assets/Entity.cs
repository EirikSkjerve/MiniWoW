using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
// Parent class for entities such as Player and Enemy
public abstract class Entity : MonoBehaviour
{
    // body to perform physics on
    public Rigidbody2D body;
    
    //various properties of the entity
    [SerializeField] private int maxHitPoints;
    [SerializeField] private int currentHitPoints;
    [SerializeField] private int maxResource;
    [SerializeField] private int currentResource;
    [SerializeField] private int level;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool inCombat;
    [SerializeField] private bool isAlive;

    //struct of combat stats 
    public struct CombatStats
    {
        public int Strength;
        public int Intellect;
        public int Agility;
        public int Stamina;
        
    }
    
    //enum of directions
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        None
    }

    private CombatStats _entityCombatStats;
    [SerializeField] private Direction currentDirection;
    
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    // returns what direction the entity is moving in, based on the current direction vector of the entity.
    private static Direction GetDirection(Vector2 vectorDirection)
    {
        return vectorDirection.y switch
        {
            > 0 when vectorDirection.x > 0 => Direction.UpRight,
            > 0 when vectorDirection.x < 0 => Direction.UpLeft,
            > 0 => Direction.Up,
            < 0 when vectorDirection.x > 0 => Direction.DownRight,
            < 0 when vectorDirection.x < 0 => Direction.DownLeft,
            < 0 => Direction.Down,
            _ => vectorDirection.x switch
            {
                > 0 => Direction.Right,
                < 0 => Direction.Left,
                _ => Direction.None
            }
        };
    }
    
    //sets the current direction of the entity, based on the input vector. Calls GetDirection()
    public void SetCurrentDirection (Vector2 vectorDirection)
    {
        currentDirection = GetDirection(vectorDirection);
    }

    // Returns the current set direction of the entity
    protected Direction GetCurrentDirection()
    {
        return currentDirection;
    }
    
    //updates the hitpoints value for the entity . Value cannot be negative or greater than max hitpoints 
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

    //returns the current hitpoints value
    public int GetHitPoints()
    {
        return currentHitPoints;
    }

    //updates the resource value for the entity. Value cannot be negative or greater than max resource-points
    protected void SetResource(int valueResource)
    {
        if (valueResource >= 0 && valueResource <= maxResource && isAlive)
        {
            currentResource = valueResource;
        }
    }
    
    //returns the current resource value
    public int GetResource()
    {
        return currentResource;
    }

    //updates the run-speed of the entity.
    //Walk speed is set to a fraction of run speed
    protected void SetRunSpeed(float valueRunSpeed)
    {
        runSpeed = valueRunSpeed;
        walkSpeed = runSpeed / 7;
    }
    
    //returns the current run speed value
    public float GetRunSpeed()
    {
        return runSpeed;
    }

    //returns the current walk speed value
    protected float GetWalkSpeed()
    {
        return walkSpeed;
    }

    //deals damage to the entity. Entity has to be alive, and damage cannot be negative.
    //if damage brings the current hitpoints value to a negative value, the hitpoints are set to 0, and the player is dead.
    public void TakeDamage(int damage)
    {
        if (!isAlive || damage < 0) return;
        
        var current = GetHitPoints();
        var updated = current - damage;
        SetHitPoints(updated > 0 ? updated : 0);
    }

    //deals healing to the entity. Entity has to be alive, and healing cannot be negative.
    //if healing brings the current hitpoints to greater than max hitpoints, hitpoints are set to max.
    public void TakeHealing(int healing)
    {
        if (!isAlive || healing <= 0) return;

        var current = GetHitPoints();
        var updated = current + healing;
        SetHitPoints(updated <= maxHitPoints ? updated : maxHitPoints);
    }
    
}
