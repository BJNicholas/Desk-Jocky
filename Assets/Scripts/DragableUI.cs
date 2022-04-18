using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseOver = false;
    private void Update()
    {
        if (mouseOver)
        {
            if (Input.GetMouseButton(0))
            {
                print("Dragging");
                gameObject.transform.position = Input.mousePosition;
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
