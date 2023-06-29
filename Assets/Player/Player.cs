using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Child class of entity. The player class represents a player object
public class Player : Entity
{
    //states are not yet implemented for the player class
    
    //player should have their own set of combat-stats
    public CombatStats PlayerCombatStats;

    //XP is only relevant for a player object.
    public int experiencePoints;
    
    // Start is called before the first frame update
    public override void Start()
    {
        
        //testing values
        SetRunSpeed(7f);
        SetHitPoints(100);
        SetResource(100);

        //sets empty direction 
        Direction playerDirection = Direction.None;

    }

    // Update is called once per frame
    public override void Update()
    {
        //no states are initialized yet
        //_currentState.UpdateState(this);

    }

    public void ChangeState(PlayerState newState)
    {
        //no states are initialized yet
        //_currentState.ExitState(this);
        //_currentState = newState;
        //_currentState.EnterState(this);
    }
}
