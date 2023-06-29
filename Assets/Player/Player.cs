using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [Header("States")] 
    
    
    public Stats PlayerStats;
    [SerializeField] private float xDir;
    [SerializeField] private float yDir;
    // Start is called before the first frame update
    public override void Start()
    {
        SetRunSpeed(7f);
        SetHitPoints(100);
        SetResource(100);
        //_currentState = new WalkingState();
        //_currentState.EnterState(this);
    }

    // Update is called once per frame
    public override void Update()
    {
        var velocity = body.velocity;
        xDir = velocity.x;
        yDir = velocity.y;
        //_currentState.UpdateState(this);

    }

    public void ChangeState(PlayerState newState)
    {
        //_currentState.ExitState(this);
        //_currentState = newState;
        //_currentState.EnterState(this);
    }
}
