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

    private List<InputActionReference> inputReferences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeRight.action.started += changeRightAction;
        changeLeft.action.started += changeLeftAction;

        inputReferences = new List<InputActionReference>();
        inputReferences.Add(movingDirection);
        StaticStates.InitializeStaticStates(playerNameFile, inputReferences);
    }

    private void Update()
    {
        StaticStates.stateMachine.GetState().Update();
    }


    void changeRightAction(InputAction.CallbackContext context)
    {
        Debug.Log("derecha");
    }

    void changeLeftAction(InputAction.CallbackContext context)
    {
        Debug.Log("izquierda");
    }
}
