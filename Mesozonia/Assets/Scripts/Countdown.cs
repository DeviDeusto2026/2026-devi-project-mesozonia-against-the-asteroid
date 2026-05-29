using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    [SerializeField] Text countDownText;
    private float seconds = 60;
    private float minutes = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //countDown();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (seconds <= 0) {
            seconds = 60;
            minutes--;
        }

        seconds -= Time.deltaTime;

        int seconds2 = (int)seconds;
        countDownText.text = "TIME LEFT: " + minutes.ToString() + " : " + seconds2.ToString();

        if (minutes <= 0 && seconds <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void countDown() {
        while (minutes > 0) {
            minutes--;
            Debug.Log("Minutos: " + minutes);
            while (seconds > 0) {
                Debug.Log("Segundos: " + seconds);
                seconds -= Time.deltaTime;
                countDownText.text = "TIME LEFT: " + minutes.ToString() + " : " + seconds.ToString();
            }
           
            seconds = 60;
        }

        if (minutes == 0) {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
