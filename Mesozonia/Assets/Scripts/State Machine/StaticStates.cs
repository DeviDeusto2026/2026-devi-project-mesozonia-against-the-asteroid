using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class StaticStates
{
    public static GameObject player;
    public static Movement move;
    public static StateMachine stateMachine;
    public static List<IState> stateListMovement;
    public static GameObject mainCamera;
    public static Quaternion modelLookingDirectionRotation;

    public static InputActionReference changeRight;
    public static InputActionReference changeLeft;

    public static void InitializeStaticStates(string playerGameObject,List<InputActionReference> inputReferences, GameObject camera)
    {
        player = GameObject.Find(playerGameObject);
        move = new Movement(player, inputReferences);
        stateListMovement = new List<IState>();
        stateListMovement.Add(new IdleState());
        stateListMovement.Add(new WalkState());
        stateListMovement.Add(new JumpState());
        stateListMovement.Add(new RunState());
        stateListMovement.Add(new ClimbState());
        stateListMovement.Add(new ChargeState());
        stateListMovement.Add(new SpecialSprintState());
        stateListMovement.Add(new FlyState());
        stateListMovement.Add(new FloatState());
        stateMachine = new StateMachine(stateListMovement[(int) STATES.IDLE]);
        stateListMovement[(int)STATES.IDLE].Enter();
        mainCamera = camera;

        changeLeft = inputReferences[4];
        changeRight = inputReferences[5];
    }
}

public enum STATES : int{
    IDLE = 0,
    WALK = 1,
    JUMP = 2,
    RUN = 3,
    CLIMB = 4,
    CHARGE = 5,
    SPECIAL_SPRINT = 6,
    FLY = 7,
    FLOAT = 8
};
