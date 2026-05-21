using System.Collections.Generic;
using UnityEngine;

public static class StaticStates
{
    public static GameObject player;
    public static Movement mv;
    public static StateMachine stateMachine;
    public static List<IState> stateListMovement;

    public static void InitializeStaticStates(string playerGameObject)
    {
        player = GameObject.Find(playerGameObject);
        mv = new Movement(player);

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
