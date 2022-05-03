using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject main, help;

    private void Start()
    {
        main.SetActive(false);
        help.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && help.activeInHierarchy == false && GameManager.instance.caseCompleteMenu.activeInHierarchy == false)
        {
            Clock.instance.GetComponent<AudioSource>().Stop();
            main.SetActive(true);
            Time.timeScale = 0;
            GameManager.instance.timeCounting = false;
        }
    }

    public void Resume()
    {
        main.SetActive(false);
        Clock.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        GameManager.instance.timeCounting = true;
    }
    public void OpenHelpScreen()
    {
        help.SetActive(true);
        main.SetActive(false);
    }
    public void CloseHelpScreen()
    {
        help.SetActive(false);
        main.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }
}
