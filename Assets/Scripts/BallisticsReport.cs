using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallisticsReport : MonoBehaviour
{
    public Text weaponUsed;


    private void Start()
    {
        weaponUsed.text = MurderManager.instance.murderWeapon.ToString();
    }
}
