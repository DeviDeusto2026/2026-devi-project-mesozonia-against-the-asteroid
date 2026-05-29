using UnityEngine;

public class SpecialSprintState : IState
{
    
    public SpecialSprintState()
    {

    }

    public void Enter()
    {
        StaticStates.move.specialSpeedAchieved = StaticStates.move.specialSpeed;
        StaticStates.move.charges = 2;
    }

    public void Update()
    {
        StaticStates.move.specialSpeed -= 0.2f;

        SharedMovement.movementOfPlayerSpecial();

        if(StaticStates.move.jump.action.ReadValue<float>() == 1)
        {
            SharedMovement.jumpPlayer();
        }

        
        if (StaticStates.move.specialSpeed <= StaticStates.move.playerWalkSpeed)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }

    public void Exit()
    {

    }
}
