using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 startMousePos;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }
    // Создание префаба при вытягивании
    public void OnBeginDrag(PointerEventData eventData)
    {
        startMousePos = eventData.position;
    }

    // Позиция префаба OnDrag
    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mousePos = eventData.position;
        lineRend.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
        lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
    }

}
