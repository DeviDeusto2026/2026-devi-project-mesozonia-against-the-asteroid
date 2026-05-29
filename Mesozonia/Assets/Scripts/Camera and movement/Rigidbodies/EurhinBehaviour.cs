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
}
