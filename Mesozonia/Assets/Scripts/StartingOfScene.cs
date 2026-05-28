using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;


public class StartingOfScene : MonoBehaviour
{
    public string playerNameFile;
    public InputActionReference movingDirection;
    public InputActionReference changeRight;
    public InputActionReference changeLeft;
    public InputActionReference jump;
    public InputActionReference sprint;
    public GameObject mainCamera;

    private List<InputActionReference> inputReferences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeRight.action.started += changeRightAction;
        changeLeft.action.started += changeLeftAction;
        jump.action.started += jumpAction;
        sprint.action.started += sprintAction;
        inputReferences = new List<InputActionReference>();
        inputReferences.Add(movingDirection);
        inputReferences.Add(jump);
        inputReferences.Add(sprint);

        StaticStates.InitializeStaticStates(playerNameFile, inputReferences, mainCamera);
    }

    private void Update()
    {
        StaticStates.stateMachine.GetState().Update();
        Debug.Log(StaticStates.stateMachine.GetState());
    }


    void changeRightAction(InputAction.CallbackContext context)
    {
        Debug.Log("derecha");
    }

    void changeLeftAction(InputAction.CallbackContext context)
    {
        Debug.Log("izquierda");
    }

    void jumpAction(InputAction.CallbackContext context)
    {
        if(StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
    }

    void sprintAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.move.movingDirection.action.ReadValue<Vector2>() != Vector2.zero)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.RUN]);
        }
    }
}
