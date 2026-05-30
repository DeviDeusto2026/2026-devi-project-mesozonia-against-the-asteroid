using UnityEngine;
using UnityEngine.UI;

public class TimeTextScript : MonoBehaviour
{

    Countdown countdown;
    [SerializeField] Text timeText;

    //private void Awake()
    //{
    //    countdown = GameObject.Find("Time").GetComponent<Countdown>();
    //}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int seconds2 = (int)PlayerData.seconds;
        timeText.text = "YOUR TIME: " + PlayerData.minutes.ToString() + ":" + seconds2.ToString();
    }

    
}
