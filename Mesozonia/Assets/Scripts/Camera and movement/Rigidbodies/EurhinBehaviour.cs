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
