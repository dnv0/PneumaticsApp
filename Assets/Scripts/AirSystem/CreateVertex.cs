using System.Collections;
using System.Collections.Generic;
using QuickGraph;
using UnityEngine;

public class CreateVertex : MonoBehaviour
{
    public string myVertexName;
    public bool isAir;

    void Start()
    {
        // Назначенение цвета материала: red
        //
        GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        
        // Генерация названия вершины графа
        //
        string parentObjectName = transform.parent.name;
        string objectName = this.name;
        string vertexName = parentObjectName + objectName; // Создание имени вершины

        myVertexName = vertexName; // Передача строки переменной с открытым модификатором доступа

        AirSystem.graphAir.AddVertex(vertexName); // Создание вершины
    }

    private void Update()
    {
        // Смена цвета материала в зависимости от наличия воздуха в точке
        //
        if (isAir)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }

        // Перключение наличия воздуха в зависимости от цвета точки графа
        //
        GraphColor c = AirSystem.dfs.VertexColors[myVertexName];
        if (c == GraphColor.Black)
        {
            isAir = true;
        }
        else isAir = false;
    }
}
