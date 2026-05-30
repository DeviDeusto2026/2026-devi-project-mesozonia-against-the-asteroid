using UnityEngine;

public class EurhinBehaviour : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if ((StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.CLIMB]))
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        }

        if(StaticStates.move.swimDown.action.ReadValue<float>() == 1 && StaticStates.move.controller.isGrounded == false && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SWIM])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.BOMB]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            if(StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.SWIM])
            {
            }
            else
            {
                StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.SWIM]);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        StaticStates.move.playerVelocity.y = 15;
        StaticStates.player.GetComponent<CharacterController>().Move(StaticStates.move.playerVelocity * Time.deltaTime);

        StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
    }
}
