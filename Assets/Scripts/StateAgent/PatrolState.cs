using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private float timer;
    public PatrolState(StateAgent owner) : base(owner) { }
    public override void OnEnter()
    {
        Debug.Log("PATROL ENTER");
        timer = Random.Range(5, 10);    
        owner.movement.Resume();
        owner.navigation.targetNode = owner.navigation.GetNearestNode();
    }

    public override void OnExit()
    {
        Debug.Log("PATROL EXIT");
    }

    public override void OnUpdate()
    {
        Debug.Log("PATROL UPDATE");
        timer -= Time.deltaTime;
        if(owner.perceived.Length > 0)
        {
            owner.stateMachine.StartState(nameof(ChaseState));
            Debug.Log("CONTROL UPDATE");
        }
        if(timer <= 0)
        {
            owner.stateMachine.StartState(nameof(PatrolState));
        }
    }
}
