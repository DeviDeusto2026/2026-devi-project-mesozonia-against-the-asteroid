using UnityEngine;

public class JumpState : IState
{
    public JumpState()
    {
    }
    
    public void Enter()
    {
        Debug.Log("Saltar es mi pasion");
        SharedMovement.jumpPlayer();
    }

    public void Update()
    {
        SharedMovement.movementOfPlayer();

        if (StaticStates.move.controller.isGrounded)
        {
            if(StaticStates.move.movingDirection.action.ReadValue<Vector2>() == Vector2.zero)
            {
                StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.IDLE]);
            }
            else
            {
                StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
            }
        }
    }

    public void Exit()
    {

    }
}
