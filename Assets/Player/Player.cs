using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [Header("States")] 
    private PlayerState _currentState;
    private PlayerState _walkingState;
    private PlayerState _idleState;
    
    public Stats PlayerStats;
    [SerializeField] private float xDir;
    [SerializeField] private float yDir;
    // Start is called before the first frame update
    public override void Start()
    {
        PlayerStats = new Stats
        {
            WalkSpeed = 2.5f,
            RunSpeed = 6f
        };
        _currentState = new WalkingState();
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    public override void Update()
    {
        xDir = body.velocity.x;
        yDir = body.velocity.y;
        //_currentState.UpdateState(this);

    }
    public void ChangeState(PlayerState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
