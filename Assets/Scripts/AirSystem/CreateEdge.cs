using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickGraph;

public class CreateEdge : MonoBehaviour
{
    private CreateVertex vertex1, vertex2;
    private bool isConnected;

    private void Start()
    {
        isConnected = false;
    }

    private void Update()
    {
        if (isConnected)
        {
            if (vertex1 == null || vertex2 == null)
            {
                if (!AirSystem.graphAir.ContainsVertex(vertex1.myVertexName) || !AirSystem.graphAir.ContainsVertex(vertex2.myVertexName))
                {
                    if (vertex1)
                        vertex1.isCabled = false;
                    if (vertex2)
                        vertex2.isCabled = false;
                    Destroy(transform.gameObject);
                }
            }
        } 
    }

    public void AddEdge(CreateVertex v1, CreateVertex v2)
    {
        vertex1 = v1;
        vertex2 = v2;
        isConnected = true;

        var edge = new TaggedUndirectedEdge<string, string>(v1.myVertexName, v2.myVertexName, "CableEdge");
        AirSystem.graphAir.AddEdge(edge);
    }
}
