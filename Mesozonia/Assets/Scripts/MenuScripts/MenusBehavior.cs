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
        PlayerData.audioscript.playSFX(PlayerData.audioscript.buttonSFX);
        SceneManager.LoadScene("StartMenu");
    }

    public void changeToOptionMenu()
    {
        PlayerData.audioscript.playSFX(PlayerData.audioscript.buttonSFX);
        SceneManager.LoadScene("OptionMenu");
    }

    public void changeToOptionMenu2()
    {
        PlayerData.audioscript.playSFX(PlayerData.audioscript.buttonSFX);
        SceneManager.LoadScene("OptionMenu2");
    }

    public void changeToLevel()
    {
        PlayerData.audioscript.playSFX(PlayerData.audioscript.buttonSFX);
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        PlayerData.audioscript.playSFX(PlayerData.audioscript.buttonSFX);
        Application.Quit();

        // Útil en el editor para probar el botón
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
