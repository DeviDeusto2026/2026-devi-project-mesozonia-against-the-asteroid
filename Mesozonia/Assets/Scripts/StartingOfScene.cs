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
    public InputActionReference specialSprint;

    public GameObject mainCamera;

    private List<InputActionReference> inputReferences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeRight.action.started += changeRightAction;
        changeLeft.action.started += changeLeftAction;
        jump.action.started += jumpAction;
        sprint.action.started += sprintAction;
        specialSprint.action.started += specialSprintAction;
        inputReferences = new List<InputActionReference>();
        inputReferences.Add(movingDirection);
        inputReferences.Add(jump);
        inputReferences.Add(sprint);
        inputReferences.Add(specialSprint);

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
        if(StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CHARGE])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
    }

    void sprintAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB] && StaticStates.move.movingDirection.action.ReadValue<Vector2>() != Vector2.zero)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.RUN]);
        }
    }

    void specialSprintAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CHARGE])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.CHARGE]);
        }

        if(StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.move.charges <= 0)
        {
            StaticStates.move.charges--;
            StaticStates.move.specialSpeed = StaticStates.move.specialSpeedAchieved;
        }
    }
}
