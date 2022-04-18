using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiscatedItems : MonoBehaviour
{
    public GameObject[] slots;

    private void Update()
    {
        if(GameManager.instance.selectedSuspect != null)
        {
            ResetSlots();
            GenerateSlots();
        }
    }
    public void ResetSlots()
    {
        foreach(GameObject slot in slots)
        {
            slot.GetComponent<Slot>().item = null;
            slot.SetActive(false);
        }

    }
    public void GenerateSlots()
    {
        int count = 0;
        int itemCount = GameManager.instance.selectedSuspect.GetComponent<Character>().items.ToArray().Length;

        if (itemCount != 0)
        {
            while (count < itemCount)
            {
                slots[count].SetActive(true);
                slots[count].GetComponent<Slot>().item = GameManager.instance.selectedSuspect.GetComponent<Character>().items[count];
                slots[count].GetComponent<Slot>().SetInfo();
                count++;
            }
        }
    }
}
