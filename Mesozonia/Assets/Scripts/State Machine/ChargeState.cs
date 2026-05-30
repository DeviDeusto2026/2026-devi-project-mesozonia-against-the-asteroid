using UnityEngine;

public class ChargeState : IState
{
    private float chargeTime = 3;
    public ChargeState()
    {

    }

    public void Enter()
    {
        chargeTime = 3;
        StaticStates.move.specialSpeed = 10;
        PlayerData.audioscript.playSFX(PlayerData.audioscript.DBcharge);
    }

    public void Update()
    {
        chargeTime -= Time.deltaTime;
        Debug.Log(chargeTime);
        StaticStates.move.specialSpeed += 0.5f; 

        if(chargeTime <= 0 || StaticStates.move.specialSprint.action.ReadValue<float>() == 0)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT]);
        }
    }

    public void Exit()
    {

    }
}
