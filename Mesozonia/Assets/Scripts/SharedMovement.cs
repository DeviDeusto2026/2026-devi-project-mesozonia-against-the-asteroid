using UnityEngine;

public class SharedMovement : MonoBehaviour
{
    public float playerWalkSpeed;
    public float playerRunSpeed;
    private float playerSpeed;

    public float jumpHeight;
    public float gravityValue;

    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectSpeed();

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable. In other words, allows it so that, when falling, it will be at the given value.
            // //Otherwise, speed always accumulates when grounded
            if (playerVelocity.y < -2f)
            {
                playerVelocity.y = -2f;
            }
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        //This is like normalizing. It ensures that, whenever we are moving, we are advancing 1 unit (1, 0, 1)->(0.7, 0, 0.7)
        move = Vector3.ClampMagnitude(move, 1f);

        //Makes it so that the character will always be moving towards the direction they are moving
        if (move != Vector3.zero)
            transform.forward = move;

        if (groundedPlayer && Input.GetKey(KeyCode.Space))
        {
            //Arbitrary formula for getting initial speed in y.
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }

    void selectSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = playerRunSpeed;
        }
        else
        {
            playerSpeed = playerWalkSpeed;
        }
    }
}
