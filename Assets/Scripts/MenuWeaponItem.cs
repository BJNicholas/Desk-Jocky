using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWeaponItem : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, -1 * speed * Time.deltaTime, 0);
    }
}
