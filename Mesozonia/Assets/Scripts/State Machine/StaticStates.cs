using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class StaticStates
{
    public static GameObject player;
    public static Movement move;
    public static StateMachine stateMachine;
    public static List<IState> stateListMovement;

    public static void InitializeStaticStates(string playerGameObject, List<InputActionReference> inputReferences)
    {
        player = GameObject.Find(playerGameObject);
        move = new Movement(player, inputReferences);
        Debug.Log(move.movingDirection.action.ReadValue<Vector2>());
        stateListMovement = new List<IState>();
        stateListMovement.Add(new IdleState());
        stateListMovement.Add(new WalkState());
        stateMachine = new StateMachine(stateListMovement[(int) STATES.IDLE]);
        stateListMovement[(int)STATES.IDLE].Enter();
    }
}

public enum STATES : int{
    IDLE = 0,
    WALK = 1
};
