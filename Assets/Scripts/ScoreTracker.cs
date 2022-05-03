using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    #region Singleton
    public static ScoreTracker instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public int reputation = 100;
    public Text repText;
    public bool hasSpent;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        hasSpent = false;
        repText.text = "Reputation: " + reputation;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "MENU")
        {
            if (repText == null)
                repText = GameObject.FindGameObjectWithTag("RepText").GetComponent<Text>();
            repText.text = "Reputation: " + reputation;
        }
    }

    public void ReduceRep(int amount)
    {
        hasSpent = true;
        reputation -= amount;
        repText.text = "Reputation: " + reputation;
    }

    public void AddRep(int amount)
    {
        reputation += amount;
        if (reputation > 200)
            reputation = 200;
        repText.text = "Reputation: " + reputation;
    }

    public bool CheckRep(int amount)
    {
        //check if we have enough rep
        if (reputation >= amount)
        {
            return true;
        }
        else //can't, so flash the rep text
        {
            StartCoroutine(FlashText());
            return false;
        }
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
