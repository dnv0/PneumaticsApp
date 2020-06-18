using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Префаб элемента и панель
    //
    public GameObject elementPrefab;
    public GameObject panelElements;

    private GameObject currentObject;
    private int counter = 0;

    // Создание объекта префаба при вытягивании
    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        currentObject = Instantiate(elementPrefab, GameObject.Find("Elements").transform);
        currentObject.name = elementPrefab.name + " " + counter;
        counter++;

        var canvGroup = panelElements.GetComponent<CanvasGroup>();
        canvGroup.alpha = 0;
    }

    // Установка позиции объекта префаба OnDrag
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
