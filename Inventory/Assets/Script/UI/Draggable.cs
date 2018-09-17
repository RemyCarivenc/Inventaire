using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        for (int j = 1; j < 9; j++)
        {
            string testRay = "Action"+j;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.name == testRay)
                    results[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            }
        }
        
            
    }
}
