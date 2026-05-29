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
    public InputActionReference fly;

    public GameObject mainCamera;
    public GameObject Drypto;
    public GameObject Tupan;
    public GameObject Eurhin;
    private int currentCharacter = 0;


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
        inputReferences.Add(changeLeft);
        inputReferences.Add(changeRight);
        inputReferences.Add(fly);

        StaticStates.InitializeStaticStates(playerNameFile, inputReferences, mainCamera);
    }

    private void Update()
    {
        StaticStates.stateMachine.GetState().Update();
        Debug.Log(StaticStates.stateMachine.GetState());
    }


    void changeRightAction(InputAction.CallbackContext context)
    {
        //if (currentCharacter != 2 && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB])
        //{
        //    StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.WALK]);
        //}
        if (currentCharacter == 0)
        {
            currentCharacter = 1;
            Drypto.SetActive(false);
            Tupan.SetActive(true);
        }
        else if(currentCharacter == 1)
        {
            currentCharacter = 2;
            Tupan.SetActive(false);
            Eurhin.SetActive(true);
        }
        else if(currentCharacter == 2)
        {
            currentCharacter = 0;
            Eurhin.SetActive(false);
            Drypto.SetActive(true);
        }
    }

    void changeLeftAction(InputAction.CallbackContext context)
    {
        if (currentCharacter == 0)
        {
            currentCharacter = 1;
            Drypto.SetActive(false);
            Eurhin.SetActive(true);
        }
        else if (currentCharacter == 1)
        {
            currentCharacter = 2;
            Eurhin.SetActive(false);
            Tupan.SetActive(true);
        }
        else if (currentCharacter == 2)
        {
            currentCharacter = 0;
            Tupan.SetActive(false);
            Drypto.SetActive(true);
        }
    }

    void jumpAction(InputAction.CallbackContext context)
    {
        if(StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CHARGE] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.FLY])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }

        if (StaticStates.move.flyCharges > 0 && StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.FLY])
        {
            Debug.Log(StaticStates.move.flyCharges);
            StaticStates.move.flyCharges--;
            SharedMovement.jumpPlayerAir();
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
        if (StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.JUMP] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CLIMB] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.CHARGE] && StaticStates.stateMachine.GetState() != StaticStates.stateListMovement[(int)STATES.FLY])
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
