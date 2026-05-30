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
        Time.timeScale = 1;

    }

    public void changeToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void changeToOptionMenu()
    {
        SceneManager.LoadScene("OptionMenu");
        Time.timeScale = 1;

    }

    public void changeToOptionMenu2()
    {
        SceneManager.LoadScene("OptionMenu2");
    }

    public void changeToLevel()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        
        Application.Quit();

        // Útil en el editor para probar el botón
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
