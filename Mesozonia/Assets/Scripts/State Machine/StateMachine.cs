using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            //The same as doing "if (currentState != null) {currentStateExit();}"
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
