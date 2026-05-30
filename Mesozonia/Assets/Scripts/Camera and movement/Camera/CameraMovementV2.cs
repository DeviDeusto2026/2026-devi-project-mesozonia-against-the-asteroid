using UnityEngine;
using UnityEngine.InputSystem;


public class CameraMovementV2 : MonoBehaviour
{
    float mouseSensitivity = 0.25f;
    private Vector2 _camera_input_direction = Vector2.zero;
    private Vector2 mousePosition;

    float pivotX;
    float pivotY;

    float pivotXGamepad;
    float pivotYGamepad;
    Vector2 minMovement;

    public GameObject cameraPivot;
    public InputActionReference recenterCamera;
    public InputActionReference gamepadCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //We hide the cursor
        //Cursor.visible = false;

        pivotX = cameraPivot.transform.rotation.x;
        pivotY = cameraPivot.transform.rotation.y;

        pivotXGamepad = cameraPivot.transform.rotation.x;
        pivotYGamepad = cameraPivot.transform.rotation.y;

        minMovement = new Vector2(0.50f, 0.50f);

        recenterCamera.action.started += cameraRecenter;
    }

    // Update is called once per frame
    void Update()
    {
        //FOR GAMEPAD
        if (gamepadCamera.action.ReadValue<Vector2>().x <= minMovement.x * -1 || gamepadCamera.action.ReadValue<Vector2>().y <= minMovement.y * -1 ||
            gamepadCamera.action.ReadValue<Vector2>().x >= minMovement.x || gamepadCamera.action.ReadValue<Vector2>().y >= minMovement.y)
        {
            Vector2 cameraMovementGamepad = gamepadCamera.action.ReadValue<Vector2>();
            pivotXGamepad += cameraMovementGamepad.y * Time.deltaTime;
            pivotXGamepad = Mathf.Clamp(pivotXGamepad, -Mathf.PI / 6.0f, Mathf.PI / 3.0f);
            pivotYGamepad -= -cameraMovementGamepad.x * Time.deltaTime;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity *200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);
        }
        

        //FOR MOUSE
        if (mousePosition == Vector2.zero)
        {
            mousePosition = Mouse.current.position.ReadValue();
        }
        Vector2 newMousePosition = Mouse.current.position.ReadValue();

        //This small block captures the screen's proportion, and checks if the mouse is inside. When it's not there, it stops.
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(Mouse.current.position.ReadValue()))
            return;

        if ((mousePosition - newMousePosition) == Vector2.zero) return;

        _camera_input_direction = (mousePosition - newMousePosition) * mouseSensitivity;
        mousePosition = newMousePosition;
        //Debug.Log(_camera_input_direction);

        pivotX += _camera_input_direction.y * Time.deltaTime;
        pivotX = Mathf.Clamp(pivotX,- Mathf.PI / 6.0f, Mathf.PI / 3.0f);
        pivotY -= _camera_input_direction.x * Time.deltaTime;
        Quaternion rotationCamera = new Quaternion(pivotX, pivotY, cameraPivot.transform.rotation.z, 1);
        //Slerp already does the clamp for us
        cameraPivot.transform.rotation = Quaternion.Slerp(cameraPivot.transform.rotation, rotationCamera, 0.5f);
        //Debug.Log(cameraPivot.transform.rotation.x);
    }

    void cameraRecenter(InputAction.CallbackContext context)
    {
        cameraPivot.transform.rotation = StaticStates.modelLookingDirectionRotation;

        pivotX = cameraPivot.transform.rotation.y;
        pivotY = cameraPivot.transform.rotation.z;

        

        pivotXGamepad = 0;

        if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().y > minMovement.y && StaticStates.move.movingDirection.action.ReadValue<Vector2>().x > minMovement.x)
        {

            pivotYGamepad += Mathf.PI / 4;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);

        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().y > minMovement.y && StaticStates.move.movingDirection.action.ReadValue<Vector2>().x < -minMovement.x)
        {

            pivotYGamepad -= Mathf.PI / 4;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);

        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().y < -minMovement.y && StaticStates.move.movingDirection.action.ReadValue<Vector2>().x > minMovement.x)
        {
            pivotYGamepad += 3 * Mathf.PI / 4;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);

        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().y < -minMovement.y && StaticStates.move.movingDirection.action.ReadValue<Vector2>().x < -minMovement.x)
        {

            pivotY += 3 * Mathf.PI / 4;
            pivotYGamepad -= 3 * Mathf.PI / 4;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);

        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().y < -minMovement.y)
        {

            pivotY += 3 * Mathf.PI / 4;
            pivotYGamepad -= Mathf.PI;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);

        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().x < -minMovement.x)
        {
            pivotY += 3 * Mathf.PI / 4;
            pivotYGamepad += 3 * Mathf.PI / 2;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);
        }
        else if (StaticStates.move.movingDirection.action.ReadValue<Vector2>().x > minMovement.x)
        {
            pivotY += 3 * Mathf.PI / 4;
            pivotYGamepad += Mathf.PI / 2;
            cameraPivot.transform.rotation = Quaternion.Euler(pivotXGamepad * mouseSensitivity * 200, pivotYGamepad * mouseSensitivity * 200, cameraPivot.transform.rotation.z);
        }

    }

    private void OnDestroy()
    {
        recenterCamera.action.started -= cameraRecenter;
    }
}
