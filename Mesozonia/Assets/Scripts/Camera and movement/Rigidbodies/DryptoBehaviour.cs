using UnityEngine;

public class DryptoBehaviour : MonoBehaviour
{

    void Update()
    {
        if ((StaticStates.changeLeft.action.ReadValue<float>() == 1 || StaticStates.changeRight.action.ReadValue<float>() == 1) && StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.CLIMB])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.CLIMB]);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.CLIMB]);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water") && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.FLOAT])
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
