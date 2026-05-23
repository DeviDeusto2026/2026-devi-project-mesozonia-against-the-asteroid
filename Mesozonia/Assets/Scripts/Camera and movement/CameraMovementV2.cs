using UnityEngine;
using UnityEngine.InputSystem;


public class CameraMovementV2 : MonoBehaviour
{
    float mouseSensitivity = 0.25f;
    private Vector2 _camera_input_direction = Vector2.zero;
    private Vector2 mousePosition;

    public GameObject cameraPivot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //We hide the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mousePosition == Vector2.zero)
        {
            mousePosition = Mouse.current.position.ReadValue();
        }
        Vector2 newMousePosition = Mouse.current.position.ReadValue();
        //This small black captures the screen's proportion, and checks if the mouse is inside. When it's not there, it stops.
        //Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        //if (!screenRect.Contains(Mouse.current.position.ReadValue()))
        //    return;

        if ((mousePosition - newMousePosition) == Vector2.zero) return;

        _camera_input_direction = (mousePosition - newMousePosition) * mouseSensitivity;
        mousePosition = newMousePosition;
        Debug.Log(_camera_input_direction);

        Quaternion rotationCamera = new Quaternion(cameraPivot.transform.rotation.x + _camera_input_direction.y * Time.deltaTime, cameraPivot.transform.rotation.y - _camera_input_direction.x * Time.deltaTime, cameraPivot.transform.rotation.z, 1);
        //Slerp already does the clamp for us
        cameraPivot.transform.rotation = Quaternion.Slerp(cameraPivot.transform.rotation, rotationCamera, 0.5f);
        //Debug.Log(rotationCamera);
    }

    private void FixedUpdate()
    {
        
    }
}
