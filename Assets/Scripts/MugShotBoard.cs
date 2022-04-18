using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MugShotBoard : MonoBehaviour
{
    public Text name, height;


    private void Update()
    {
        string abrvName = transform.parent.gameObject.GetComponent<Character>().firstName[0].ToString() + "." + transform.parent.gameObject.GetComponent<Character>().lastName;
        name.text = abrvName;
        height.text = transform.parent.gameObject.GetComponent<Character>().height.ToString() + "cm";
    }
}
