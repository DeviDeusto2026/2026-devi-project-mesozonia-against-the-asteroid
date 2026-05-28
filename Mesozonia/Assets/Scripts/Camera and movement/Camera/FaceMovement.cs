using UnityEngine;



public class FaceMovement : MonoBehaviour
{

    //This script must be added only to the models, not the empty gameobject with the character controller.
    //This is purely for the visuals.

    void Update()
    {
        if(StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB])
        {
            Vector2 movingDirection = StaticStates.move.movingDirection.action.ReadValue<Vector2>();
            Vector3 forward = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.forward);
            forward.y = 0;
            Vector3 ForwardRelative = movingDirection.y * forward;

            Vector3 right = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.right);
            right.y = 0;
            Vector3 RightRelative = movingDirection.x * right;
            Vector3 move = ForwardRelative + RightRelative;

            this.transform.forward = move;
            StaticStates.modelLookingDirectionRotation = this.transform.rotation;
        }
        
    }
}
