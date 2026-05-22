using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;


public class StartingOfScene : MonoBehaviour
{
    public string playerNameFile;
    public InputActionReference movingDirection;
    private List<InputActionReference> inputReferences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputReferences = new List<InputActionReference>();
        inputReferences.Add(movingDirection);
        StaticStates.InitializeStaticStates(playerNameFile, inputReferences);
    }

    private void Update()
    {
        Debug.Log(movingDirection.action.IsPressed());
        Debug.Log("-----" +movingDirection.action.ReadValue<Vector2>());
        StaticStates.stateMachine.GetState().Update();
    }
}
