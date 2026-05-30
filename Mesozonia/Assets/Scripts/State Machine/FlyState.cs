using UnityEngine;

public class FlyState : IState
{
    public FlyState()
    {
        
    }

    public void Enter()
    {
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
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.IDLE]);
        }

        if (StaticStates.move.fly.action.ReadValue<float>() == 0)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
    }

    public void Exit()
    {

    }
}
