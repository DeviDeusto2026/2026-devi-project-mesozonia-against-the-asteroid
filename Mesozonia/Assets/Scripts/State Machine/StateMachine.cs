using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public StateMachine(IState currentState)
    {
        this.currentState = currentState;
    }

    public void ChangeState(IState newState)
    {
     //The same as doing "if (currentState != null) {currentStateExit();}"
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    //It exits and enters the new state
    public void Update()
    {
        Debug.Log(this.currentState);
        GetState().Update();
        //currentState?.Exit();
    }

    public IState GetState()
    {
        return this.currentState;
    }
}
