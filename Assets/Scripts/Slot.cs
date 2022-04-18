using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;

    public Text itemName;
    public Image sprite;

    public void SetInfo()
    {
        itemName.text = item.name;
        sprite.sprite = item.GetComponent<SpriteRenderer>().sprite;
    }
}
