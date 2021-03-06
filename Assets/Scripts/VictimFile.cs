using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictimFile : MonoBehaviour
{
    public Text victimName, height, age, profession;
    [Header("Manner of Death")]
    public Text cause;
    public Text location;


    private void Update()
    {
        victimName.text = MurderManager.instance.victimName;
        height.text = MurderManager.instance.victimHeight.ToString() + "cm";
        age.text = MurderManager.instance.victimAge.ToString();
        profession.text = MurderManager.instance.victimProfession.ToString();

        cause.text = MurderManager.instance.causeOfDeath.ToString();
        location.text = MurderManager.instance.murderLocation.ToString();

    }
}
