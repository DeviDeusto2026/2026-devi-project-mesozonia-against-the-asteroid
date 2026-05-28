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
        SharedMovement.climbingOfPlayer(10);
    }

    public void Exit()
    {

    }
}
