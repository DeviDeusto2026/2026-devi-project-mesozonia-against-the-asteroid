using UnityEngine;
using UnityEngine.InputSystem;


public class CameraMovementV2 : MonoBehaviour
{
    float mouseSensitivity = 0.25f;
    private Vector2 _camera_input_direction = Vector2.zero;
    private Vector2 mousePosition;

    float pivotX;
    float pivotY;
    public GameObject cameraPivot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //We hide the cursor
        Cursor.visible = false;

        pivotX = cameraPivot.transform.rotation.x;
        pivotY = cameraPivot.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
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
}
