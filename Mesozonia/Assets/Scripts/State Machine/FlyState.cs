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
        if (StaticStates.move.sprint.action.ReadValue<float>() == 0)
        {
            SharedMovement.flyingOfPlayer();
        }
        else
        {
            SharedMovement.flyingOfPlayer(StaticStates.move.playerRunSpeed);
        }


        if (StaticStates.move.controller.isGrounded)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }

    public void Exit()
    {

    }
}
