using UnityEngine;

public class FloatState : IState
{
    private float timer;
    public FloatState()
    {

    }

    public void Enter()
    {
        timer = 0.1f;
        Debug.Log("FLOATING STATE");
    }

    public void Update()
    {
        if(timer > 0)
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
