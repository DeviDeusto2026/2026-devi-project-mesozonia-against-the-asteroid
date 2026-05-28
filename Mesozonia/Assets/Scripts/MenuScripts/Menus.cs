using System;
using Unity.VisualScripting;
using UnityEngine;

public class Menus : MonoBehaviour
{

    public bool isActive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openOptionMenu();
    }

    private void openOptionMenu() {
        if (Input.GetKeyDown(KeyCode.Escape) && isActive == true)
        {
            this.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && isActive == false) {
            this.gameObject.SetActive(true);
        }
    }
}
