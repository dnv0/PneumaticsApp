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


    public CreateVertex GetVertexObjectByName(string vertexName)
    {
        CreateVertex[] components = GameObject.FindObjectsOfType<CreateVertex>();

        foreach (CreateVertex v in components)
        {
            if (v.myVertexName == vertexName)
            {
                return v;
            }
        }

        return null;
    }

    // Удаление всех пневмоэлементов
    //
    public void ClearWorkField()
    {
        foreach (Transform child in transform.Find("Elements"))
        {
            if (child.name != "Cables")
            {
                Destroy(child.gameObject);
            }
        }
    }
}
