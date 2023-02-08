using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private float timer;

    public IdleState(StateAgent owner) : base(owner) { }
    public override void OnEnter()
    {
        Debug.Log("IDLE ENTER");
        timer = 2;
    }

    public override void OnExit()
    {
        Debug.Log("IDLE EXIT");
    }

    public override void OnUpdate()
    {
        Debug.Log("IDLE UPDATE");
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            owner.stateMachine.StartState(nameof(PatrolState));
        }
    }
}
