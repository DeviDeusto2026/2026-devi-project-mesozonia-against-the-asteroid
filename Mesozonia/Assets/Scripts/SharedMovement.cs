using UnityEngine;

public class SharedMovement
{
    public static CharacterController controller;
    public static Vector2 movingDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static void movementOfPlayer()
    {
        //Movement on X and Z
        Vector3 movement = movePlayer();
        //Debug.Log("This is the move after: " + movement);

        //Gravity
        ApplyGravity();
        //movement.y = playerVelocity.y;
        // Move
        Vector3 finalMove = movement * StaticStates.move.playerWalkSpeed + Vector3.up * StaticStates.move.playerVelocity.y;

        StaticStates.player.GetComponent<CharacterController>().Move(finalMove * Time.deltaTime);
    }

    public static void movementOfPlayer(float speed)
    {
        //Movement on X and Z
        Vector3 movement = movePlayer();
        //Debug.Log("This is the move after: " + movement);

        //Gravity
        ApplyGravity();
        //movement.y = playerVelocity.y;
        // Move
        Vector3 finalMove = movement * speed + Vector3.up * StaticStates.move.playerVelocity.y;

        StaticStates.player.GetComponent<CharacterController>().Move(finalMove * Time.deltaTime);
    }

    static Vector3 movePlayer()
    {
        movingDirection = StaticStates.move.movingDirection.action.ReadValue<Vector2>();
        Vector3 forward = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.forward);
        forward.y = 0;
        Vector3 ForwardRelative = movingDirection.y * forward;

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

    public static void jumpPlayer()
    {
        //Need to convert to new input system
        if (StaticStates.move.controller.isGrounded)
        {
            //Arbitrary formula for getting initial speed in y.
            StaticStates.move.playerVelocity.y = Mathf.Sqrt(StaticStates.move.jumpHeight * -2f * StaticStates.move.gravityValue);
        }
        StaticStates.player.GetComponent<CharacterController>().Move(StaticStates.move.playerVelocity * Time.deltaTime);
    }

    public static void ApplyGravity()
    {
        if (StaticStates.move.controller.isGrounded)
        {
            // Slight downward velocity to keep grounded stable. In other words, allows it so that, when falling, it will be at the given value.
            // //Otherwise, speed always accumulates when grounded
            if (StaticStates.move.playerVelocity.y < -2f)
            {
                StaticStates.move.playerVelocity.y = -2f;
            }
        }
        // Apply gravity
        StaticStates.move.playerVelocity.y += StaticStates.move.gravityValue * Time.deltaTime;
        StaticStates.player.GetComponent<CharacterController>().Move(StaticStates.move.playerVelocity * Time.deltaTime);

    }

    public static void climbingOfPlayer(float speed)
    {
        //Movement on X and Z
        Vector3 movement = climbPlayer();
        //Debug.Log("This is the move after: " + movement);

        
        //movement.y = playerVelocity.y;
        // Move
        Vector3 finalMove = movement * speed;

        StaticStates.player.GetComponent<CharacterController>().Move(finalMove * Time.deltaTime);
    }

    static Vector3 climbPlayer()
    {
        movingDirection = StaticStates.move.movingDirection.action.ReadValue<Vector2>();
        Vector3 up = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.up);
        up.z = 0;
        Vector3 UpRelative = movingDirection.y * up;

        Vector3 right = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.right);
        right.z = 0;
        Vector3 RightRelative = movingDirection.x * right;
        Vector3 move =UpRelative + RightRelative;

        //This is like normalizing. It ensures that, whenever we are moving, we are advancing 1 unit (1, 0, 1)->(0.7, 0, 0.7)
        move = Vector3.ClampMagnitude(move, 1f);


        return move;
    }

    public static void movementOfPlayerSpecial()
    {
        //Movement on X and Z
        Vector3 movement = movePlayerSpecial();
        //Debug.Log("This is the move after: " + movement);

        //Gravity
        ApplyGravity();
        // Move
        Vector3 finalMove = movement * StaticStates.move.specialSpeed + Vector3.up * StaticStates.move.playerVelocity.y;

        StaticStates.player.GetComponent<CharacterController>().Move(finalMove * Time.deltaTime);
    }

    static Vector3 movePlayerSpecial()
    {
        movingDirection = StaticStates.move.movingDirection.action.ReadValue<Vector2>();
        Vector3 forward = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.forward);
        forward.y = 0;
        //With this conditional we try to make it imposible to special sprint while not going forward.
        if(movingDirection.y <= 0.5)
        {
            movingDirection.y = 0.5f;
        }
        Vector3 ForwardRelative = movingDirection.y * forward;

        Vector3 right = StaticStates.player.transform.InverseTransformVector(StaticStates.mainCamera.transform.right);
        right.y = 0;
        Vector3 RightRelative = movingDirection.x/4 * right;
        Vector3 move = ForwardRelative + RightRelative;

        //This is like normalizing. It ensures that, whenever we are moving, we are advancing 1 unit (1, 0, 1)->(0.7, 0, 0.7)
        move = Vector3.ClampMagnitude(move, 1f);

        //Makes it so that the character will always be moving towards the direction they are moving
        //if (move != Vector3.zero)
        //    StaticStates.player.transform.forward = ForwardRelative;


        return move;

    }
}

