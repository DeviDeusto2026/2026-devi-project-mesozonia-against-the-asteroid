using UnityEngine;

public class Movement
{
    public StateMachine stateMachine;
    public float playerWalkSpeed;
    public float playerRunSpeed;
    //private float playerSpeed;

    public float jumpHeight;
    public float gravityValue;

    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;

    public Movement(GameObject player, StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerWalkSpeed = 3;
        playerRunSpeed = 5;

        jumpHeight = 3;
        gravityValue = -9.8f;

        controller = player.GetComponent<CharacterController>();

    }
}
