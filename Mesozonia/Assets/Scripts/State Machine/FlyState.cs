using UnityEngine;

public class FlyState : IState
{
    public FlyState()
    {
        
    }

    public void Enter()
    {
        StaticStates.move.flyCharges = 2;
        StaticStates.move.playerVelocity.y = 0;

    }

    public void Update()
    {
        SharedMovement.flyingOfPlayer();
        

        if (StaticStates.move.controller.isGrounded)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }

    public void Exit()
    {

    }
}
