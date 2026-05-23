using UnityEngine;

public class SharedMovement
{
    public static CharacterController controller;
    public static Vector3 playerVelocity;
    public static Vector2 movingDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    static void selectSpeed()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    playerSpeed = playerRunSpeed;
        //}
        //else
        //{
        //    playerSpeed = playerWalkSpeed;
        //}
    }

    public static void movementOfPlayer()
    {
        selectSpeed();

        //Movement on X and Z
        Vector3 movement = movePlayer();
        Debug.Log("This is the move after: " + movement);

        //Jump
        jumpPlayer();
        //movement.y = playerVelocity.y;
        // Move
        Vector3 finalMove = movement * StaticStates.move.playerWalkSpeed + Vector3.up * playerVelocity.y;

        StaticStates.player.GetComponent<CharacterController>().Move(finalMove * Time.deltaTime);
    }

    static Vector3 movePlayer()
    {
        movingDirection = StaticStates.move.movingDirection.action.ReadValue<Vector2>();
        Vector3 forward = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.forward);
        forward.y = 0;
        Vector3 ForwardRelative = movingDirection.y *forward;
        
        Vector3 right = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.right);
        right.y = 0;
        Vector3 RightRelative = movingDirection.x * right;
        Vector3 move = ForwardRelative + RightRelative;

        //This is like normalizing. It ensures that, whenever we are moving, we are advancing 1 unit (1, 0, 1)->(0.7, 0, 0.7)
        move = Vector3.ClampMagnitude(move, 1f);

        //Makes it so that the character will always be moving towards the direction they are moving
        //if (move != Vector3.zero)
        //    StaticStates.player.transform.forward = ForwardRelative;
        

        return move;
        

    }

    private static void jumpPlayer()
    {
        //If the player is grounded
        if (StaticStates.move.controller.isGrounded)
        {
            // Slight downward velocity to keep grounded stable. In other words, allows it so that, when falling, it will be at the given value.
            // //Otherwise, speed always accumulates when grounded
            if (playerVelocity.y < -2f)
            {
                playerVelocity.y = -2f;
            }
        }

        //Need to convert to new input system
        //if (StaticStates.move.controller.isGrounded && Input.GetKey(KeyCode.Space))
        //{
        //    //Arbitrary formula for getting initial speed in y.
        //    playerVelocity.y = Mathf.Sqrt(StaticStates.move.jumpHeight * -2f * StaticStates.move.gravityValue);
        //}

        // Apply gravity
        playerVelocity.y += StaticStates.move.gravityValue * Time.deltaTime;


    }

}

//selectSpeed();

//groundedPlayer = controller.isGrounded;

//if (groundedPlayer)
//{
//    // Slight downward velocity to keep grounded stable. In other words, allows it so that, when falling, it will be at the given value.
//    // //Otherwise, speed always accumulates when grounded
//    if (playerVelocity.y < -2f)
//    {
//        playerVelocity.y = -2f;
//    }
//}

//Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

////This is like normalizing. It ensures that, whenever we are moving, we are advancing 1 unit (1, 0, 1)->(0.7, 0, 0.7)
//move = Vector3.ClampMagnitude(move, 1f);

////Makes it so that the character will always be moving towards the direction they are moving
//if (move != Vector3.zero)
//    transform.forward = move;

//if (groundedPlayer && Input.GetKey(KeyCode.Space))
//{
//    //Arbitrary formula for getting initial speed in y.
//    playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
//}

//// Apply gravity
//playerVelocity.y += gravityValue * Time.deltaTime;

//// Move
//Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
//controller.Move(finalMove * Time.deltaTime);