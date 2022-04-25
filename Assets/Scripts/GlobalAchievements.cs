using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalAchievements : MonoBehaviour
{
    #region Singleton
    public static GlobalAchievements instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GlobalAchievements found");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject[] newlyUnlockedAchievements;
    public GameObject newAchDisplay;

    [Space]
    [Header("Achievement 1")]
    public GameObject ach01UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach01Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach01Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach01Aquired = 0;

    [Space]
    [Header("Achievement 2")]
    public GameObject ach02UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach02Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach02Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach02Aquired = 0;

    [Space]
    [Header("Achievement 3")]
    public GameObject ach03UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach03Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach03Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach03Aquired = 0;

    [Space]
    [Header("Achievement 4")]
    public GameObject ach04UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach04Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach04Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach04Aquired = 0;

    [Space]
    [Header("Achievement 5")]
    public GameObject ach05UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach05Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach05Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach05Aquired = 0;

    [Space]
    [Header("Achievement 6")]
    public GameObject ach06UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach06Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach06Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach06Aquired = 0;

    [Space]
    [Header("Achievement 7")]
    public GameObject ach07UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach07Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach07Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach07Aquired = 0;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        ach01Aquired = PlayerPrefs.GetInt("Ach01");
        if (ach01Aquired != 0)
        {
            Trigger01Ach();
        }

        ach02Aquired = PlayerPrefs.GetInt("Ach02");
        if (ach02Aquired != 0)
        {
            Trigger02Ach();
        }

        ach03Aquired = PlayerPrefs.GetInt("Ach03");
        if (ach03Aquired != 0)
        {
            Trigger03Ach();
        }

        ach04Aquired = PlayerPrefs.GetInt("Ach04");
        if (ach04Aquired != 0)
        {
            Trigger04Ach();
        }

        ach05Aquired = PlayerPrefs.GetInt("Ach05");
        if (ach05Aquired != 0)
        {
            Trigger05Ach();
        }

        ach06Aquired = PlayerPrefs.GetInt("Ach06");
        if (ach06Aquired != 0)
        {
            Trigger06Ach();
        }

        ach07Aquired = PlayerPrefs.GetInt("Ach07");
        if (ach07Aquired != 0)
        {
            Trigger07Ach();
        }
    }

    void Update()
    {
        if(ach01Count == ach01Trigger && ach01Aquired == 0)
        {
            Trigger01Ach();
        }

        if (ach02Count == ach02Trigger && ach02Aquired == 0)
        {
            Trigger02Ach();
        }

        if (ach03Count == ach03Trigger && ach03Aquired == 0)
        {
            Trigger03Ach();
        }

        if (ach04Count == ach04Trigger && ach04Aquired == 0)
        {
            Trigger04Ach();
        }

        if (ach05Count == ach05Trigger && ach05Aquired == 0)
        {
            Trigger05Ach();
        }

        if (ach06Count == ach06Trigger && ach06Aquired == 0)
        {
            Trigger06Ach();
        }

        if (ach07Count == ach07Trigger && ach07Aquired == 0)
        {
            Trigger07Ach();
        }
    }

    //solved first case
    public void Trigger01Ach()
    {
        ach01Aquired = 1;
        PlayerPrefs.SetInt("Ach01", 1);
        ach01UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved 3 cases
    public void Trigger02Ach()
    {
        ach02Aquired = 1;
        PlayerPrefs.SetInt("Ach02", 1);
        ach02UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved 10 cases
    public void Trigger03Ach()
    {
        ach03Aquired = 1;
        PlayerPrefs.SetInt("Ach03", 1);
        ach03UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved 3 cases in a row
    public void Trigger04Ach()
    {
        ach04Aquired = 1;
        PlayerPrefs.SetInt("Ach04", 1);
        ach04UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved a case in under 15 seconds
    public void Trigger05Ach()
    {
        ach05Aquired = 1;
        PlayerPrefs.SetInt("Ach05", 1);
        ach05UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved a case without questions
    public void Trigger06Ach()
    {
        ach06Aquired = 1;
        PlayerPrefs.SetInt("Ach06", 1);
        ach06UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    //solved a case without spending rep
    public void Trigger07Ach()
    {
        ach07Aquired = 1;
        PlayerPrefs.SetInt("Ach07", 1);
        ach07UI.transform.GetChild(3).gameObject.SetActive(false);
    }
}
