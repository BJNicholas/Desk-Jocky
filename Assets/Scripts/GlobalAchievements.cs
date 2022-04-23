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
    [Header("Achievment 1")]
    public GameObject ach01UI;
    [Tooltip("Current progress toward achievement")]
    public static int ach01Count;
    [Tooltip("How many triggers does it take to achieve?")]
    public int ach01Trigger = 1;
    [Tooltip("0 means not yet achieved")]
    public int ach01Aquired = 0;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        ach01Aquired = PlayerPrefs.GetInt("Ach01");
        if (ach01Aquired != 0)
        {
            Trigger01Ach();
        }
    }

    void Update()
    {
        if(ach01Count == ach01Trigger && ach01Aquired == 0)
        {
            Trigger01Ach();
        }
    }

    //solved first case
    public void Trigger01Ach()
    {
        ach01Aquired = 1;
        print("A");
        PlayerPrefs.SetInt("Ach01", 1);
        Instantiate(ach01UI, newAchDisplay.transform);
    }
}
