using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickGraph;
using QuickGraph.Algorithms.Search;

public  class AirSystem : MonoBehaviour
{
    // Объявление графа
    //
    public static UndirectedGraph<string, UndirectedEdge<string>> graphAir = new UndirectedGraph<string, UndirectedEdge<string>>(false);

    // Объявление DFS Алгоритма
    //
    public static UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>> dfs = new UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>>(graphAir);

    // Количество педалей
    //
    public static int pedalCounter = 0;

    public static int compressorCounter = 0;

    private void Update()
    {
        // Запуск алгоритма DFS
        //
        dfs.Compute("CompressorOutput");
    }

    // Кнопка ингейм дебага
    //
    public void OutputLog()
    {
        foreach (var v in graphAir.Vertices)
            Debug.Log(v);
        foreach (var e in graphAir.Edges)
            Debug.Log(e);
        Debug.Log("Pedals Count: " + pedalCounter);
    }

}
