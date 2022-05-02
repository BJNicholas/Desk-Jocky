using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectFile : MonoBehaviour
{
    #region Singleton
    public static SuspectFile instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SuspectFile found");
            return;
        }
        instance = this;
    }
    #endregion
    public Text suspectName, height, age, profession;

    public GameObject inButton, guButton;

    [Tooltip("The current correct streak of the player")]
    public int streak;

    private void Start()
    {
        streak = PlayerPrefs.GetInt("streak");
    }


    private void Update()
    {
        if(GameManager.instance.selectedSuspect != null)
        {
            suspectName.text = GameManager.instance.selectedSuspect.GetComponent<Character>().fullName;
            height.text = GameManager.instance.selectedSuspect.GetComponent<Character>().height.ToString();
            age.text = GameManager.instance.selectedSuspect.GetComponent<Character>().age.ToString();
            profession.text = GameManager.instance.selectedSuspect.GetComponent<Character>().profession.ToString();
            inButton.SetActive(true);
            guButton.SetActive(true);
        }
        else
        {
            inButton.SetActive(false);
            guButton.SetActive(false);
            suspectName.text = "-";
            height.text = "-";
            age.text = "-";
            profession.text = "-";
        }
    }

    public void Innocent()
    {
        GameManager.instance.selectedSuspect.SetActive(false);
        GameManager.instance.selectedSuspect = null;

        int remainingSuspects = GameObject.FindGameObjectsWithTag("Suspect").Length;
        if (remainingSuspects <= 0)
        {
            GameManager.instance.timeCounting = false;
            GameManager.instance.clock.GetComponent<AudioSource>().Stop();
            GameManager.instance.caseCompleteMenu.SetActive(true);
            CaseComplete.instance.result.text = "Innocent";
            streak = 0;
            PlayerPrefs.SetInt("streak", 0);
        }

    }
    public void Guilty()
    {
        GameManager.instance.timeCounting = false;
        GameManager.instance.clock.GetComponent<AudioSource>().Stop();
        if (GameManager.instance.selectedSuspect == MurderManager.instance.murderer)
        {
            print("WELL DONE");
            GameManager.instance.caseCompleteMenu.SetActive(true);
            GameManager.instance.AddTime(10);
            CaseComplete.instance.result.text = "Guilty";

            //add 1 to total cases solved
            GlobalAchievements.ach01Count += 1;
            GlobalAchievements.ach02Count += 1;
            GlobalAchievements.ach03Count += 1;

            //add to the streak and check for achievement
            streak += 1;
            PlayerPrefs.SetInt("streak", streak);

            if(PlayerPrefs.GetInt("streak") >= 3)
            {
                GlobalAchievements.ach04Count += 1;
            }
            
            //check the time remaining
            if (GameManager.timeRemaining >= 45)
            {
                GlobalAchievements.ach05Count += 1;
            }

            //check if the player used any questions
            if(Witness.noQuestions == true)
            {
                GlobalAchievements.ach06Count += 1;
            }

            //check if the player has spent any rep
            if (ScoreTracker.instance.hasSpent == false)
            {
                GlobalAchievements.ach07Count += 1;
            }

        }
        else
        {
            GameManager.instance.caseCompleteMenu.SetActive(true);
            CaseComplete.instance.result.text = "Innocent";
            streak = 0;
            PlayerPrefs.SetInt("streak", 0);
        }
    }
}
