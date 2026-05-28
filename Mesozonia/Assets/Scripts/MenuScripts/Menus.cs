using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menus : MonoBehaviour
{

    public GameObject panelOptions;
    public InputActionReference escape;

    public bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escape.action.started += escapeAction;
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    void escapeAction(InputAction.CallbackContext context) {
        Debug.Log("Se ha llamado");
        if (isActive == false) {
            Time.timeScale = 0;
            Debug.Log("Activado");
            panelOptions.SetActive(true);
            
        }
        if (isActive == true) {
            Time.timeScale = 1;
            Debug.Log("Desactivado");
            panelOptions.SetActive(false);
            
        }

        isActive = !isActive;
    }
}
