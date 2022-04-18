using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaseComplete : MonoBehaviour
{
    public static CaseComplete instance;
    public Text result;

    private void Awake()
    {
        instance = this;
    }


    public void NextCase()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
