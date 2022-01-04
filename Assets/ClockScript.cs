using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockScript : MonoBehaviour {

    public int hour, minute, second;
    public int gameDurationInMinutes = 20;
    
    private GameObject hourHand;
    private GameObject minuteHand;
    private GameObject secondHand;
    private int secondsLeft;

    void Start () {
        hourHand = GameObject.Find("HourHand");
        minuteHand = GameObject.Find("MinuteHand");
        secondHand = GameObject.Find("SecondHand");

        secondsLeft = gameDurationInMinutes * 60;
        int secondsAngle = second * 6;
        int minutesAngle = minute * 6;
        secondHand.transform.Rotate(new Vector3(0, 1, 0), -secondsAngle);
        minuteHand.transform.Rotate(new Vector3(0, 1, 0),-( minutesAngle + secondsAngle / 60));
        hourHand.transform.Rotate(new Vector3(0, 1, 0), - (hour * 30 + minutesAngle / 12  + secondsAngle / 3600));
        InvokeRepeating("moveHands", 1, 1);
    }

    private void moveHands()
    {
        secondsLeft--;
        hourHand.transform.Rotate(new Vector3(0, 1, 0), -1/72f);
        minuteHand.transform.Rotate(new Vector3(0, 1, 0), -0.1f);
        secondHand.transform.Rotate(new Vector3(0, 1, 0), -6);
    }
    
	void Update ()
    {
        if (secondsLeft <= 0)
        {
            SceneManager.LoadScene((int)ApplicationLevel.Lose);
        }
    }
}
