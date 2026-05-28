using UnityEngine;

public class Continue : MonoBehaviour
{

    public GameObject panelOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ContinueLevel() { 
        panelOptions.SetActive(false);
    }
}
