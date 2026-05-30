using UnityEngine;
using UnityEngine.UI;

public class TimeTextScript : MonoBehaviour
{

    Countdown countdown;
    [SerializeField] Text timeText;

    private void Awake()
    {
        countdown = GameObject.Find("Time").GetComponent<Countdown>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText.text = "YOUR TIME: " + countdown.playerMinutes + ":" + countdown.playerSeconds;
    }

    
}
