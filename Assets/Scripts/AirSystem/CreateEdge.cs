using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickGraph;

public class CreateEdge : MonoBehaviour
{
    private string vertex1, vertex2;

    private void Update()
    {
        if (vertex1 != null && vertex2 != null)
        {
            if (!AirSystem.graphAir.ContainsVertex(vertex1) || !AirSystem.graphAir.ContainsVertex(vertex2))
            {
                Destroy(transform.gameObject);
            }
        }
    }

    public void AddEdge(string v1, string v2)
    {
        vertex1 = v1;
        vertex2 = v2;

        var edge = new TaggedUndirectedEdge<string, string>(v1, v2, "Edge");
        AirSystem.graphAir.AddEdge(edge);
    }
}
