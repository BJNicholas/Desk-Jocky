using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    public GameObject printer;
    public GameObject fingerMarkReportPrefab;

    public Button fingerprintButton;

    private void Update()
    {
        fingerprintButton.interactable = GameManager.instance.selectedSuspect; 
    }

    public void FingerPrintReport()
    {
        GameObject newReport = Instantiate(fingerMarkReportPrefab, printer.transform);
        newReport.GetComponent<FingerMarkReport>().nameTXT.text = GameManager.instance.selectedSuspect.GetComponent<Character>().fullName;
        printer.GetComponent<AudioSource>().Play();

        //Turn off pop up
        gameObject.SetActive(false);
    }
}
