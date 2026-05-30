using UnityEngine;

public class WalkState : IState
{
    private Movement player;

    public WalkState()
    {
    }

    public void Enter()
    {
        PlayerData.audioscript.StartWalking();
    }

   public void Update()
    {
        
        SharedMovement.movementOfPlayer();

        if (StaticStates.move.movingDirection.action.ReadValue<Vector2>() == Vector2.zero)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.IDLE]);
        }
    }

    public void Exit()
    {
        PlayerData.audioscript.StopWalking();
    }
}
