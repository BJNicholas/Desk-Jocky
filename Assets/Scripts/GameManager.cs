using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float timeRemaining;
    public float startingTime;
    public bool timeCounting = true;
    public GameObject clock;
    public GameObject[] suspects;
    public GameObject[] items;

    public GameObject selectedSuspect = null;

    public GameObject caseCompleteMenu;


    public enum causesOfDeath
    {
        Stabbed,
        Shot,
        Strangled,
        Poisoned,
        Beaten,
        debug
    }
    public enum professions
    {
        Labourer,
        Bartender,
        Soldier,
        Butcher,
        Chef,
        Doctor,
        debug
    }
    public enum weapons
    {
        Knife,
        Scalpel,
        Pistol,
        Rifle,
        Hands,
        Cane,
        Pills,
        Syringe,
        debug
    }
    public enum locations
    {
        Home,
        Work,
        Restaurant,
        Shops,
        debug
    }


    private void Awake()
    {
        instance = this;
        clock.GetComponent<AudioSource>().Play();
        if (timeRemaining <= 0)
        {
            ResetTime();
        }
    }
    private void Start()
    {
        ResetTime();
    }

    private void FixedUpdate()
    {
        if(timeCounting) timeRemaining -= 1 * Time.deltaTime;
        print(timeRemaining);

        if(timeRemaining <= 0)
        {
            timeCounting = false;
            clock.GetComponent<AudioSource>().Stop();
            caseCompleteMenu.SetActive(true);
            CaseComplete.instance.result.text = "Time Expired";
        }
    }

    public void ResetTime()
    {
        timeRemaining = startingTime;
    }
    public void AddTime(float amount)
    {
        timeRemaining += amount;
        if (timeRemaining >= 60)
            timeRemaining = 60;
    }
    public float GetTimeRemaining(float time)
    {
        time = timeRemaining;
        return time;
    }
}
