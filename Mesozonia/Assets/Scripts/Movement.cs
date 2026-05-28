using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Movement
{
    public float playerWalkSpeed;
    public float playerRunSpeed;

    public float jumpHeight;
    public float gravityValue;

    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
    public InputActionReference movingDirection;
    public InputActionReference jump;
    public InputActionReference sprint;


    public Movement(GameObject player, List<InputActionReference> inputReferences)
    {
        playerWalkSpeed = 7;
        playerRunSpeed = 14;

        jumpHeight = 3;
        gravityValue = -9.8f;

        movingDirection = inputReferences[0];
        jump = inputReferences[1];
        sprint = inputReferences[2];
        controller = player.GetComponent<CharacterController>();
    }
}
