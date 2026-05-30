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
        Vector3 direction = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(StaticStates.player.transform.position,
                            StaticStates.player.transform.forward,
                            out hit))
        {
            direction = -hit.normal;
            //Debug.Log("The normal: " + direction);
        }




        //TODO allow jumping
        if (StaticStates.move.sprint.action.ReadValue<float>() == 0)
        {
            SharedMovement.climbingOfPlayer(10, direction);
        }
        else
        {
            SharedMovement.climbingOfPlayer(20, direction);
        }
    }

    public void Exit()
    {

    }
}
