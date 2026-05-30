using UnityEngine;

public class TupanBehaviour : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if ((StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.CLIMB]))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }

        if(StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.move.fly.action.ReadValue<float>() == 1)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.FLY]);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Water") && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.FLOAT])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.FLOAT]);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
    }
}
