using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickGraph;

public class CreateEdge : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Первая и вторая вершина
    //
    string vertex1, vertex2;


    // 
    //
    private bool hitFlag;

    // Cable system
    //
    public GameObject cableObject;
    private CableComponent cable;
    private GameObject currentCableObject;

    GameObject nullObject;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            var selection = hit.transform;
            
            if (hit.collider.tag.Equals("Vertex"))
            {
                Debug.Log("HITTED!");
                hitFlag = true;

                var thisGameObject = hit.transform.gameObject.GetComponent<CreateVertex>();

                vertex1 = thisGameObject.myVertexName;

                nullObject = new GameObject();
                nullObject.name = "Pointer";

                currentCableObject = Instantiate(cableObject, GameObject.Find("Cables").transform);
                cable = currentCableObject.GetComponent<CableComponent>();
                cable.Begin = hit.transform;
                cable.End = nullObject.transform;

            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hitFlag)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                nullObject.transform.position = hit.point;

                cable.End = nullObject.transform;


            }
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
            if (hit.collider.tag.Equals("Vertex"))
            {


                // Запись второй вершины
                //
                var thisGameObject = hit.transform.gameObject.GetComponent<CreateVertex>();
                vertex2 = thisGameObject.myVertexName;
                
                var e1 = new TaggedUndirectedEdge<string, string>(vertex1, vertex2,"hello");

                

                Debug.Log(hit.transform.name);

                // Исключение взаимно обратных рёбер и петель
                // Ограничение степени вершины
                // Создание ребра
                //
                if (!AirSystem.graphAir.ContainsEdge(e1.Target, e1.Source) && vertex1 != vertex2 && AirSystem.graphAir.AdjacentDegree(vertex1) < 2 && AirSystem.graphAir.AdjacentDegree(vertex2) < 2)
                {
                    AirSystem.graphAir.AddEdge(e1);
                    Debug.Log("Edge added!: "+ e1);

                    // Защита от переназначения точек соединения кабеля
                    //
                    if (cable)
                    {
                        cable.End = hit.transform;
                        cable = null;

                        Destroy(nullObject);
                    }
                }
                else
                {
                    Destroy(currentCableObject);
                    Destroy(nullObject);
                }
            }
            else{

                Destroy(currentCableObject);
                Destroy(nullObject);
            }
        }
    }
}
