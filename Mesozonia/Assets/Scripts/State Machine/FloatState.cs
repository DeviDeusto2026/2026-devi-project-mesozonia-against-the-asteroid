using UnityEngine;

public class FloatState : IState
{
    private float timer;
    public FloatState()
    {

    }

    public void Enter()
    {
        if (StaticStates.changeLeft.action.ReadValue<float>() == 1 || StaticStates.changeRight.action.ReadValue<float>() == 1)
        {
            timer = 0;
        }
        else
        {
            timer = 0.1f;

        }
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
