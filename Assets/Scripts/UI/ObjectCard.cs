using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject currentObject; // Префаб элемента
    public GameObject panelElements;


    // Создание префаба при вытягивании
    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        currentObject = Instantiate(currentObject, GameObject.Find("Elements").transform);
        var canvGroup = panelElements.GetComponent<CanvasGroup>();
        canvGroup.alpha = 0;
    }

    // Позиция префаба OnDrag
    //
    public void OnDrag(PointerEventData eventData)
    {
        currentObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 20));
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var canvGroup = panelElements.GetComponent<CanvasGroup>();
        canvGroup.alpha = 1;
    }

}
