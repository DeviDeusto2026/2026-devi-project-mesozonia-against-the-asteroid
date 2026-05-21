using UnityEngine;
using Unity.Cinemachine;


public class CameraRecentering : MonoBehaviour
{

    public CinemachineFreeLook camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //camera = GetComponent<CinemachineFreeLook>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera.m_RecenterToTargetHeading.m_enabled = true;
        }
        else {
            camera.m_RecenterToTargetHeading.m_enabled = false;        
        }
    }
}
