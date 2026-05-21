using UnityEngine;

public class WalkState : IState
{
    private Movement player;
    private int i;

    public WalkState()
    {
        i = 0;
    }

    public void Enter()
    {
        Debug.Log("Walk State Entrado");
    }

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            i++;
            Debug.Log(i);
            Debug.Log("guau");
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.IDLE]);
        }
    }

    public void Exit()
    {
        Debug.Log("Walkstate salido");
    }
}
