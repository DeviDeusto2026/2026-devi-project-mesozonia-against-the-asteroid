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
    public InputActionReference swimUp;
    public InputActionReference swimDown;


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
        inputReferences.Add(swimUp);
        inputReferences.Add(swimDown);


        StaticStates.InitializeStaticStates(playerNameFile, inputReferences, mainCamera, Drypto.GetComponent<Rigidbody>(), Tupan.GetComponent<Rigidbody>(), Eurhin.GetComponent<Rigidbody>());
    }

    private void Update()
    {
        StaticStates.stateMachine.GetState().Update();
        //Debug.Log(StaticStates.stateMachine.GetState());

        if (StaticStates.move.controller.isGrounded)
        {
            StaticStates.move.flyCharges = 2;
        }
    }


    void changeRightAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.SWIM]) return;

        if (Drypto.activeInHierarchy == true)
        {
            Drypto.SetActive(false);
            Tupan.SetActive(true);
        }
        else if(Tupan.activeInHierarchy == true)
        {
            currentCharacter = 2;
            Tupan.SetActive(false);
            Eurhin.SetActive(true);

            if(StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.FLY])
            {
                StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
            }
        }
        else if(Eurhin.activeInHierarchy == true)
        {
            currentCharacter = 0;
            Eurhin.SetActive(false);
            Drypto.SetActive(true);
        }
    }

    void changeLeftAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.SWIM]) return;

        if (Drypto.activeInHierarchy == true)
        {
            currentCharacter = 1;
            Drypto.SetActive(false);
            Eurhin.SetActive(true);
        }
        else if (Eurhin.activeInHierarchy == true)
        {
            currentCharacter = 2;
            Eurhin.SetActive(false);
            Tupan.SetActive(true);
        }
        else if (Tupan.activeInHierarchy == true)
        {
            currentCharacter = 0;
            Tupan.SetActive(false);
            Drypto.SetActive(true);

            if (StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.FLY])
            {
                StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
            }
        }
    }

    void jumpAction(InputAction.CallbackContext context)
    {
        if (StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.FLOAT])
        {
            SharedMovement.jumpPlayerAir();
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.JUMP]);
        }
        else if(StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.WALK] || StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.IDLE] || StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.RUN])
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
         if (StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.WALK] || StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.IDLE])
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.RUN]);
        }
    }

    void specialSprintAction(InputAction.CallbackContext context)
    {
        if ((StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.WALK] || StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.IDLE] || StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.RUN] ) && Drypto.activeInHierarchy == true)
        {
            StaticStates.stateMachine.ChangeState(StaticStates.stateListMovement[(int)STATES.CHARGE]);
        }

        else if(StaticStates.stateMachine.GetState() == StaticStates.stateListMovement[(int)STATES.SPECIAL_SPRINT] && StaticStates.move.charges > 0)
        {
            Debug.Log("CHARGE USED");
            StaticStates.move.charges--;
            StaticStates.move.specialSpeed = StaticStates.move.specialSpeedAchieved;
        }
    }
}
