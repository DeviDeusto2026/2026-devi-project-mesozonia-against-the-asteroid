using UnityEngine;

public class IdleState : IState
{
    public IdleState()
    {

    }

    public void Enter()
    {
        Debug.Log("IdleState Entrado");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("mmiau");
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int) STATES.WALK]);
        }
    }
    public void Exit()
    {
        Debug.Log("IdleState Salido");
    }
}
