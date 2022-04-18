using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject printer;
    public GameObject fingerMarkReportPrefab;

    public void FingerPrintReport()
    {
        GameObject newReport = Instantiate(fingerMarkReportPrefab, printer.transform);
        newReport.GetComponent<FingerMarkReport>().nameTXT.text = GameManager.instance.selectedSuspect.GetComponent<Character>().fullName;

        //Turn off pop up
        gameObject.SetActive(false);
    }
}
