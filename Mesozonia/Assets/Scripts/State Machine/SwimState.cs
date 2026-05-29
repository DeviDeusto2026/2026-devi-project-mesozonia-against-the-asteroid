using UnityEngine;

public class SwimState : IState
{
    private float timer;
    public SwimState()
    {

    }
    public void Enter()
    {
        timer = 0.3f;
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            SharedMovement.movementOfPlayer();

        }
        else
        {
            if (StaticStates.move.swimUp.action.ReadValue<float>() == 1)
            {
                SharedMovement.ApplySwimUp();
            }
            else if (StaticStates.move.swimDown.action.ReadValue<float>() == 1)
            {
                SharedMovement.ApplySwimDown();
            }

            if (StaticStates.move.sprint.action.ReadValue<float>() == 0)
            {
                SharedMovement.floatingOfPlayer(StaticStates.move.playerWalkSpeed);
            }
            else
            {
                SharedMovement.floatingOfPlayer(StaticStates.move.playerRunSpeed);
            }
        }
        
    }

    public void Exit()
    {

    }
}
