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

    public Movement(GameObject player, List<InputActionReference> inputReferences)
    {
        playerWalkSpeed = 5;
        playerRunSpeed = 8;

        jumpHeight = 3;
        gravityValue = -9.8f;

        movingDirection = inputReferences[0];
        controller = player.GetComponent<CharacterController>();
    }
}
