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
        SharedMovement.ApplyGravity();
        if (StaticStates.move.movingDirection.action.ReadValue<Vector2>() != Vector2.zero)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }
    public void Exit()
    {
        Debug.Log("IdleState Salido");
    }
}
