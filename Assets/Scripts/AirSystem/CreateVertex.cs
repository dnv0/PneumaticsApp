using System.Collections;
using System.Collections.Generic;
using QuickGraph;
using UnityEngine;

public class CreateVertex : MonoBehaviour
{
    public string myVertexName;
    public bool isAir;
    public bool isCabled;
    public float pressureValue;

    void Start()
    {
        isCabled = false;

        // Генерация названия вершины графа
        //
        string parentObjectName = transform.parent.name;
        string objectName = this.name;
        string vertexName = parentObjectName + objectName; // Создание имени вершины

        myVertexName = vertexName; // Передача строки переменной с открытым модификатором доступа

        AirSystem.graphAir.AddVertex(vertexName); // Создание вершины
    }


    // Удаление вершины из графа при удалении объекта
    //
    private void OnDestroy()
    {
        AirSystem.graphAir.RemoveVertex(myVertexName);
    }
}
