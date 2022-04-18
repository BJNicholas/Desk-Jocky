using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    public GameObject actionsBoard;
    public GameObject printer;
    [Header("Actions and Costs")]
    public GameObject fingerMarkReportPrefab;
    public int fingerprintCost = 20;
    public GameObject ballisticsReportPrefab;
    public int ballisticsCost = 20;
    public GameObject autopsyReportPrefab;
    public int autopsyCost = 20;
    [Header("Buttons")]
    public Button fingerprintButton;
    public Button ballisticsButton;
    public Button autopsyButton;

    private void Update()
    {
        fingerprintButton.interactable = GameManager.instance.selectedSuspect;
        autopsyButton.interactable = true;
        if (MurderManager.instance.causeOfDeath == GameManager.causesOfDeath.Shot) ballisticsButton.interactable = true;
    }

    public void FingerPrintReport()
    {
        if (ScoreTracker.instance.CheckRep(fingerprintCost))
        {
            ScoreTracker.instance.ReduceRep(fingerprintCost);
            GameObject newReport = Instantiate(fingerMarkReportPrefab, printer.transform);
            printer.GetComponent<AudioSource>().Play();

            //Turn off pop up
            gameObject.SetActive(false);
        }
    }
    public void BallisticsReport()
    {
        if (ScoreTracker.instance.CheckRep(ballisticsCost))
        {
            ScoreTracker.instance.ReduceRep(ballisticsCost);
            GameObject newReport = Instantiate(ballisticsReportPrefab, printer.transform);
            printer.GetComponent<AudioSource>().Play();

            //Turn off pop up
            gameObject.SetActive(false);
        }
    }
    public void AutopsyReport()
    {
        if (ScoreTracker.instance.CheckRep(autopsyCost))
        {
            ScoreTracker.instance.ReduceRep(autopsyCost);
            GameObject newReport = Instantiate(autopsyReportPrefab, printer.transform);
            printer.GetComponent<AudioSource>().Play();

            //Turn off pop up
            gameObject.SetActive(false);
        }
    }

    bool toggle;
    public void ToggleActionsBoard()
    {
        toggle = !toggle;
        actionsBoard.SetActive(toggle);
    }
}
