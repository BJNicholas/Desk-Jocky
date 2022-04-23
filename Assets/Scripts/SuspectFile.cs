using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectFile : MonoBehaviour
{
    public Text suspectName, height, age, profession;

    public GameObject inButton, guButton;


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
        }
    }

    public void Innocent()
    {
        GameManager.instance.selectedSuspect.SetActive(false);
    }
    public void Guilty()
    {
        if(GameManager.instance.selectedSuspect == MurderManager.instance.murderer)
        {
            print("WELL DONE");
            GameManager.instance.caseCompleteMenu.SetActive(true);
            CaseComplete.instance.result.text = "Guilty";
            //add 1 to total cases solved
            GlobalAchievements.ach01Count += 1;
        }
        else
        {
            GameManager.instance.caseCompleteMenu.SetActive(true);
            CaseComplete.instance.result.text = "Innocent";
        }
    }
}
