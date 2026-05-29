using UnityEngine;

public class ChargeState : IState
{
    private float chargeTime = 5;
    public ChargeState()
    {

    }

    public void Enter()
    {
        chargeTime = 5;
        StaticStates.move.specialSpeed = 10;
    }

    public void Update()
    {
        chargeTime -= Time.deltaTime;
        Debug.Log(chargeTime);
        StaticStates.move.specialSpeed += 0.3f; 

        if(chargeTime <= 0 || StaticStates.move.specialSprint.action.ReadValue<float>() == 0)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT]);
        }
    }

    public void Exit()
    {

    }
}
