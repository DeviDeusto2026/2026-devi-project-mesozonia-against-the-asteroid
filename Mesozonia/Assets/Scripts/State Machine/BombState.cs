using UnityEngine;

public class BombState : IState
{
    public BombState()
    {

    }
    public void Enter()
    {
        PlayerData.audioscript.playSFX(PlayerData.audioscript.falling);
    }

    public void Update()
    {
        SharedMovement.applyBombGravity();
        if (StaticStates.move.sprint.action.ReadValue<float>() == 0)
        {
            SharedMovement.movementOfPlayer();
        }
        else if (StaticStates.move.sprint.action.ReadValue<float>() == 1)
        {
            SharedMovement.movementOfPlayer(StaticStates.move.playerRunSpeed);
        }

        if(StaticStates.move.swimDown.action.ReadValue<float>() == 0 && StaticStates.move.controller.isGrounded == true)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.IDLE]);

        }
    }

    public void Exit()
    {

    }
}
