using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    #region Singleton
    public static ScoreTracker instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ScoreTracker found");
            return;
        }
        instance = this;
    }
    #endregion

    public int reputation = 100;
    public Text repText;

    private void Start()
    {
        repText.text = "Reputation: " + reputation;
    }

    public void ReduceRep(int amount)
    {
        //try to buy the thing
        if (reputation >= amount)
        {
            reputation -= amount;
            repText.text = "Reputation: " + reputation;
        }
        else //can't, so flash the rep text
        {
            StartCoroutine(FlashText());
        }
    }

    public void AddRep(int amount)
    {

    }

    IEnumerator FlashText()
    {
        //get the original colour of the text
        Color originalColor = repText.color;
        //change it to red
        repText.color = Color.red;
        //wait
        yield return new WaitForSeconds(0.1f);
        //change it back
        repText.color = originalColor;
        //wait
        yield return new WaitForSeconds(0.1f);
        //change it to red
        repText.color = Color.red;
        //wait
        yield return new WaitForSeconds(0.1f);
        //change it back
        repText.color = originalColor;
    }
}
