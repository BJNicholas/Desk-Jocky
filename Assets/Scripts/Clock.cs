using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject clockHand;
    public Text timer;
    public AudioClip ticking, alarm;

    bool alarmStarted = false;

    public void FixedUpdate()
    { 
        float timeRe = 0f;
        timeRe = GameManager.instance.GetTimeRemaining(timeRe);
        Vector3 handpos = new Vector3(0,0,(timeRe + 6.5f) * 6);
        clockHand.transform.localRotation = Quaternion.Euler(handpos);

        timer.text = timeRe.ToString("00");

        if(timeRe <= 10 && alarmStarted == false)
        {
            GetComponent<AudioSource>().clip = alarm;
            GetComponent<AudioSource>().Play();

            alarmStarted = true;
        }
        else if(timeRe > 10)
        {
            GetComponent<AudioSource>().clip = ticking;
            alarmStarted = false;
        }

    }
}
