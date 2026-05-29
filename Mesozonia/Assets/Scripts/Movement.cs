using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Movement
{
    public float playerWalkSpeed;
    public float playerRunSpeed;
    public float specialSpeed;
    public float specialSpeedAchieved;

    public float jumpHeight;
    public float gravityValue;
    public float gravityValueFlying;

    public float swimDownValue;
    public float swimUpValue;


    public CharacterController controller;
    public Vector3 playerVelocity;

    public int charges = 2;
    public int flyCharges = 2;

    public InputActionReference movingDirection;
    public InputActionReference jump;
    public InputActionReference sprint;
    public InputActionReference specialSprint;
    public InputActionReference fly;
    public InputActionReference swimUp;
    public InputActionReference swimDown;



    public Movement(GameObject player, List<InputActionReference> inputReferences)
    {
        playerWalkSpeed = 20;
        playerRunSpeed = 40;

        jumpHeight = 9;
        gravityValue = -14f;
        gravityValueFlying = -1f;

        swimDownValue = -1500f;
        swimUpValue = +1500f;

        movingDirection = inputReferences[0];
        jump = inputReferences[1];
        sprint = inputReferences[2];
        specialSprint = inputReferences[3];
        fly = inputReferences[6];
        swimUp = inputReferences[7];
        swimDown = inputReferences[8];
        controller = player.GetComponent<CharacterController>();
    }
}
