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

    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;

    public int charges = 2;
    public InputActionReference movingDirection;
    public InputActionReference jump;
    public InputActionReference sprint;
    public InputActionReference specialSprint;


    public Movement(GameObject player, List<InputActionReference> inputReferences)
    {
        playerWalkSpeed = 20;
        playerRunSpeed = 40;

        jumpHeight = 9;
        gravityValue = -14f;

        movingDirection = inputReferences[0];
        jump = inputReferences[1];
        sprint = inputReferences[2];
        specialSprint = inputReferences[3];
        controller = player.GetComponent<CharacterController>();
    }
}
