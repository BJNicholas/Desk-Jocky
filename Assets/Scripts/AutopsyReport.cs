using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutopsyReport : MonoBehaviour
{
    public Text weaponUsed, TOD;


    private void Start()
    {
        weaponUsed.text = MurderManager.instance.murderWeapon.ToString();
        if(MurderManager.instance.timeOfDeath > 12)
        {
            TOD.text = (MurderManager.instance.timeOfDeath - 12).ToString("00pm");
        }
        else
        {
            TOD.text = (MurderManager.instance.timeOfDeath - 0).ToString("00am");
        }
    }

}
