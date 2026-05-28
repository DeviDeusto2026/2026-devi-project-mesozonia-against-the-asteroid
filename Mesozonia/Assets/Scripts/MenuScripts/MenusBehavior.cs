using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusBehavior : MonoBehaviour
{

    public GameObject panelOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueLevel()
    {
        panelOptions.SetActive(false);
    }

    public void changeToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void changeToOptionMenu()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void changeToLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
