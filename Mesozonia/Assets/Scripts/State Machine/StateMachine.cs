using UnityEngine;

public class StateMachine
{
    private IState currentState;

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
        currentState?.Exit();
    }
}
