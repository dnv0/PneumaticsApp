using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickGraph;

public class FittingObject : MonoBehaviour
{
    // Инициализация вершин фитинга
    //
    private CreateVertex input, output1, output2;

    private void Update()
    {
        if (!input || !output1 || !output2)
        {
            input = transform.Find("Input").GetComponent<CreateVertex>();
            output1 = transform.Find("Output 1").GetComponent<CreateVertex>();
            output2 = transform.Find("Output 2").GetComponent<CreateVertex>();
        }
        else
        {
            if (!AirSystem.graphAir.ContainsEdge(input.myVertexName, output1.myVertexName) || !AirSystem.graphAir.ContainsEdge(input.myVertexName, output2.myVertexName))
            {
                var edge1 = new TaggedUndirectedEdge<string, string>(input.myVertexName, output1.myVertexName, "FittingEdge1");
                var edge2 = new TaggedUndirectedEdge<string, string>(input.myVertexName, output2.myVertexName, "FittingEdge2");
                AirSystem.graphAir.AddEdge(edge1);
                AirSystem.graphAir.AddEdge(edge2);
            }
        }
    }
}
