using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickGraph;
using UnityEngine.UI;

public class DistributorHandleObject : MonoBehaviour
{
    // Инициализация вершин распределителя
    //
    private CreateVertex input, output1, output2;

    // Слайдер
    //
    private Canvas canv;
    private Slider slider;

    private void Start()
    {
        // Получение компонентов вершин
        //
        input = transform.Find("Input").GetComponent<CreateVertex>();
        output1 = transform.Find("Output 1").GetComponent<CreateVertex>();
        output2 = transform.Find("Output 2").GetComponent<CreateVertex>();
        //

        // Получение компонента сладйера
        //
        canv = this.transform.Find("Canvas").GetComponent<Canvas>();
        slider = canv.GetComponentInChildren<Slider>();
        //
    }

    private void Update()
    {
        // В позиции 1: если есть "ребро 1" или "ребро 2", удалем их из графа
        //
        if (slider.value == 1)
        {
            if(AirSystem.graphAir.ContainsEdge(input.myVertexName, output1.myVertexName) || AirSystem.graphAir.ContainsEdge(input.myVertexName, output2.myVertexName))
            {
                if(AirSystem.graphAir.TryGetEdge(input.myVertexName, output1.myVertexName, out var e1))
                    AirSystem.graphAir.RemoveEdge(e1);

                if(AirSystem.graphAir.TryGetEdge(input.myVertexName, output2.myVertexName, out var e2))
                    AirSystem.graphAir.RemoveEdge(e2);
            }
        }

        // В позиции 0: Если есть "ребро 2" или нет "ребра 1", удаляем "ребро 2" и добавляем "ребро 1" в граф
        //
        if (slider.value == 0)
        {
            if (AirSystem.graphAir.ContainsEdge(input.myVertexName, output2.myVertexName) || !AirSystem.graphAir.ContainsEdge(input.myVertexName, output1.myVertexName))
            {
                var e1 = new TaggedUndirectedEdge<string, string>(input.myVertexName, output1.myVertexName, "DistributorEdge1");

                AirSystem.graphAir.AddEdge(e1);

                AirSystem.graphAir.TryGetEdge(input.myVertexName, output2.myVertexName, out var e2);
                AirSystem.graphAir.RemoveEdge(e2);
            }
        }

        // В позиции 2: Если есть "ребро 1" или нет "ребра 2", удаляем "ребро 1" и добавляем "ребро 2" в граф
        //
        if (slider.value == 2)
        {
            if (AirSystem.graphAir.ContainsEdge(input.myVertexName, output1.myVertexName) || !AirSystem.graphAir.ContainsEdge(input.myVertexName, output2.myVertexName))
            {
                var e2 = new TaggedUndirectedEdge<string, string>(input.myVertexName, output2.myVertexName, "DistributorEdge2");

                AirSystem.graphAir.AddEdge(e2);

                AirSystem.graphAir.TryGetEdge(input.myVertexName, output1.myVertexName, out var e1);
                AirSystem.graphAir.RemoveEdge(e1);
            }
        }
    }
}
