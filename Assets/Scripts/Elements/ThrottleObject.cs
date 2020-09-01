using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickGraph;
using QuickGraph.Algorithms.Search;
using UnityEngine.UI;

public class ThrottleObject : MonoBehaviour
{
    // Инициализация вершин распределителя
    //
    private CreateVertex input, output;

    private UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>> dfs;
    private AirSystem airSystem;

    private Canvas canv;
    private Slider slider;

    // Флаг необходимый для претовращения отключения воздуха в каждый фрейм
    //
    private bool isMethodCalled;

    // Start is called before the first frame update
    void Start()
    {
        dfs = new UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>>(AirSystem.graphAir);

        // Получение компонентов вершин
        //
        input = transform.Find("Input").GetComponent<CreateVertex>();
        output = transform.Find("Output").GetComponent<CreateVertex>();

        // Получение компонента слайдера
        //
        canv = this.transform.Find("Canvas").GetComponent<Canvas>();
        slider = canv.GetComponentInChildren<Slider>();

        // Получение компонента AirSystem
        //
        airSystem = GameObject.Find("PneumaticSystem").GetComponent<AirSystem>();

        isMethodCalled = false;

        Debug.Log("input name: " + input.myVertexName + " output name: " + output.myVertexName);
    }

    void Update()
    {
        if (input.isAir)
        {
            ToggleAirWalking(output.myVertexName, true);
            isMethodCalled = false;
        }
        else
        {
            if (!isMethodCalled)
            {
                ToggleAirWalking(output.myVertexName, false);
                isMethodCalled = true;
            }
        }
    }


    // Включение и отключение воздуха по ветке исходящая из точки vertexSource
    //
    private void ToggleAirWalking(string vertexSource, bool turnTo)
    {
        dfs.Compute(vertexSource);

        if (turnTo == true)
        {
            foreach (var u in AirSystem.graphAir.Vertices)
            {
                if (dfs.VertexColors[u] == GraphColor.Black)
                {
                    CreateVertex currentVertex = airSystem.GetVertexObjectByName(u);
                    currentVertex.isAir = true;
                    currentVertex.pressureValue = input.pressureValue - input.pressureValue * slider.value / 100;
                }
            }
        }
        else
        {
            foreach (var u in AirSystem.graphAir.Vertices)
            {
                if (dfs.VertexColors[u] == GraphColor.Black)
                {
                    airSystem.GetVertexObjectByName(u).isAir = false;
                    airSystem.GetVertexObjectByName(u).pressureValue = 0;
                }
            }
        }
    }

    private void GetVertexComponents()
    {
        if (!input || !output)
        {
            input = transform.Find("Input").GetComponent<CreateVertex>();
            output = transform.Find("Output").GetComponent<CreateVertex>();
        }
    }

    private void OnDestroy()
    {
        foreach (var u in AirSystem.graphAir.Vertices)
        {
            if (dfs.VertexColors[u] == GraphColor.Black)
            {
                CreateVertex currentVertex = airSystem.GetVertexObjectByName(u);
                currentVertex.isAir = false;
                currentVertex.pressureValue = 0;
            }
        }
    }
}
