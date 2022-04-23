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
    
    //solved a case without witness questions
    public void Trigger03Ach()
    {
        ach02Aquired = 1;
        PlayerPrefs.SetInt("Ach02", 1);
        ach02UI.transform.GetChild(3).gameObject.SetActive(false);
    }
}
