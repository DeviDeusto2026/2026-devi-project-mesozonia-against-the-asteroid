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

    public CharacterController controller;
    public Vector3 playerVelocity;

    public int charges = 2;
    public int flyCharges = 2;

    public InputActionReference movingDirection;
    public InputActionReference jump;
    public InputActionReference sprint;
    public InputActionReference specialSprint;
    public InputActionReference fly;


    public Movement(GameObject player, List<InputActionReference> inputReferences)
    {
        playerWalkSpeed = 20;
        playerRunSpeed = 40;

        jumpHeight = 9;
        gravityValue = -14f;
        gravityValueFlying = -1f;

        movingDirection = inputReferences[0];
        jump = inputReferences[1];
        sprint = inputReferences[2];
        specialSprint = inputReferences[3];
        fly = inputReferences[6];
        controller = player.GetComponent<CharacterController>();
    }
}
