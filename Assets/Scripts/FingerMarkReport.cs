using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerMarkReport : MonoBehaviour
{
    public Text nameTXT;
    public GameObject character;

    public GameObject[] prints;

    private void Start()
    {
        if(character == MurderManager.instance.murderer)
        {
            int roll = Random.Range(0, prints.Length);

            GameObject murdererPrint = Instantiate(MurderManager.instance.fingerPrint, prints[roll].transform);
            murdererPrint.GetComponent<FingerprintGenerator>().randomise = false;
            prints[roll].SetActive(false);
        }
    }
}
