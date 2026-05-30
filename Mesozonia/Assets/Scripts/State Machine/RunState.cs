using UnityEngine;

public class RunState : IState
{
    public RunState()
    {

    }
    public void Enter()
    {
        PlayerData.audioscript.StartRunning();
    }
    public void Update()
    {
        SharedMovement.movementOfPlayer(StaticStates.move.playerRunSpeed);
        if (StaticStates.move.sprint.action.ReadValue<float>() == 0)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }
    
    public void Exit()
    {
        PlayerData.audioscript.StopRunning();
    }
}
