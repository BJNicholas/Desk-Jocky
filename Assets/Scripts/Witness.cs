using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Witness : MonoBehaviour
{
    public string statement = "";

    public GameObject diologBox;
    public Text diolog;

    public int repPerQuestion;
    public string heightDesc;
    public string beardDesc;
    public string hatDesc;

    //these are randomised to check if the question returns a useful answer or not
    public int heightReliable;
    public int hairReliable;
    public int hatReliable;

    private void Start()
    {
        diologBox.SetActive(false);

        heightReliable = Random.Range(1, 100);
        hairReliable = Random.Range(1, 100);
        hatReliable = Random.Range(1, 100);
    }

    private void Update()
    {
        diolog.text = statement;
    }


    public void HeightQuestion()
    {
        //sets the button uninteractable
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;


        if (ScoreTracker.instance.CheckRep(repPerQuestion))
        {
            ScoreTracker.instance.ReduceRep(repPerQuestion);
            //check if the question is reliable
            if (heightReliable >= 34)
            {
                if (MurderManager.instance.murderer.GetComponent<Character>().height < 160)
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
            else
            {
                statement += "I didn't get a good look at his height. ";
                diologBox.SetActive(true);
            }
        }
    }
    public void BeardQuestion()
    {
        //sets the button uninteractable
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        if (ScoreTracker.instance.CheckRep(repPerQuestion))
        {
            ScoreTracker.instance.ReduceRep(repPerQuestion);

            if (hairReliable >= 34)
            {
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
            else
            {
                statement += "I couldn't see his face. ";
                diologBox.SetActive(true);
            }
        }
    }
    public void HatQuestion()
    {
        //sets the button uninteractable
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        if (ScoreTracker.instance.CheckRep(repPerQuestion))
        {
            ScoreTracker.instance.ReduceRep(repPerQuestion);

            if (hatReliable >= 34)
            {
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
            else
            {
                statement += "I'm not sure, sorry. ";
                diologBox.SetActive(true);
            }
        }
    }
}