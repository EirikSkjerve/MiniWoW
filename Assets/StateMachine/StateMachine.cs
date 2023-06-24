using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State exampleState = new StateExample();
    
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = exampleState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(State newState) {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
