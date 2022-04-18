using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Witness : MonoBehaviour
{
    public string statement = "";

    public GameObject diologBox;
    public Text diolog;

    public int repPerQuestion;
    public string heightDesc;
    public string beardDesc;
    public string hatDesc;

    private void Start()
    {
        diologBox.SetActive(false);
    }

    private void Update()
    {
        diolog.text = statement;
    }


    public void HeightQuestion()
    {
        ScoreTracker.instance.ReduceRep(repPerQuestion);
        if(MurderManager.instance.murderer.GetComponent<Character>().height < 160)
        {
            heightDesc = "short";
        }
        if (MurderManager.instance.murderer.GetComponent<Character>().height >= 160)
        {
            heightDesc = "just an average height for a";
        }
        if (MurderManager.instance.murderer.GetComponent<Character>().height >= 190)
        {
            heightDesc = "tall";
        }


        statement += "He was a " + heightDesc + " man. ";
        diologBox.SetActive(true);
    }
    public void BeardQuestion()
    {
        ScoreTracker.instance.ReduceRep(repPerQuestion);
        if (MurderManager.instance.murderer.GetComponent<Character>().bearded == true)
        {
            beardDesc = "did";
        }
        else
        {
            beardDesc = "did'nt";
        }

        statement += "He " + beardDesc + " have facial hair. ";
        diologBox.SetActive(true);
    }
    public void HatQuestion()
    {
        ScoreTracker.instance.ReduceRep(repPerQuestion);
        if (MurderManager.instance.murderer.GetComponent<Character>().wearingHat == true)
        {
            hatDesc = "was";
        }
        else
        {
            hatDesc = "was'nt";
        }
        statement += "He " + hatDesc + " wearing a hat. ";
        diologBox.SetActive(true);
    }
}
