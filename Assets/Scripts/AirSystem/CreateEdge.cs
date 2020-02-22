﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickGraph;

public class CreateEdge : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    string vertex1, vertex2;

    // Line Renderer Variables
    private LineRenderer lineRend;
    private Vector3 mousePos;
    private Vector3 startMousePos;
    private bool hitFlag;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("HITTED W/O TAG");
            var selection = hit.transform;
            
            if (selection.CompareTag("Vertex"))
            {
                Debug.Log("HITTED!");
                hitFlag = true;
                startMousePos = hit.transform.position; // Start Position of the Line
                lineRend.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, startMousePos.z));
                var thisGameObject = hit.transform.gameObject.GetComponent<CreateVertex>();
                vertex1 = thisGameObject.myVertexName;  // Запись первой вершины
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hitFlag)
        {
            lineRend.SetPosition(1, new Vector3(eventData.position.x, eventData.position.y, 0f));
        }
    }  

    public void OnEndDrag(PointerEventData eventData)
    {
        hitFlag = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Vertex"))
            {
                mousePos = hit.transform.position; // End Position of the Line
                lineRend.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, startMousePos.z));
                lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, mousePos.z));

                var thisGameObject = hit.transform.gameObject.GetComponent<CreateVertex>();
                vertex2 = thisGameObject.myVertexName;  // Запись второй вершины
                
                var e1 = new TaggedUndirectedEdge<string, string>(vertex1, vertex2,"hello");
               
                // Исключение взаимно обратных рёбер и петель
                // Создание ребра
                if (!AirSystem.graphAir.ContainsEdge(e1.Target, e1.Source) && vertex1 != vertex2)
                {
                    AirSystem.graphAir.AddEdge(e1);
                    Debug.Log("Edge added!: "+ e1);
                }

            }
        }
    }
}
