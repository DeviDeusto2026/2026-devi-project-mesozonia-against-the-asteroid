using UnityEngine;

public class ClimbState : IState
{
    public ClimbState()
    {

    }

    public void Enter()
    {

    }

    public void Update()
    {
        //TODO polish for shift key and allow jumping
        if(StaticStates.move.sprint.action.ReadValue<float>() == 0)
        {
            SharedMovement.climbingOfPlayer(10);
        }
        else
        {
            SharedMovement.climbingOfPlayer(20);
        }
    }

    public void Exit()
    {

    }
}
