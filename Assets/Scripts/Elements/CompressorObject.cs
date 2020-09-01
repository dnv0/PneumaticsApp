using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuickGraph;
using QuickGraph.Algorithms.Search;

public class CompressorObject : MonoBehaviour
{
    private UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>> dfs;

    private Canvas canv;
    private Slider slider;
    private CreateVertex output;

    private AirSystem airSystem;

    //public bool status;

    void Start()
    {
        dfs = new UndirectedDepthFirstSearchAlgorithm<string, UndirectedEdge<string>>(AirSystem.graphAir);
        output = GetComponentInChildren<CreateVertex>();

        canv = this.transform.Find("Canvas").GetComponent<Canvas>();
        slider = canv.GetComponentInChildren<Slider>();

        airSystem = GameObject.Find("PneumaticSystem").GetComponent<AirSystem>();
    }

    private void Update()
    {
        dfs.Compute(output.myVertexName);

        if (slider.value > 0)
        {
            foreach (var u in AirSystem.graphAir.Vertices)
            {
                if (dfs.VertexColors[u] == GraphColor.Black)
                {
                    airSystem.GetVertexObjectByName(u).isAir = true;
                    airSystem.GetVertexObjectByName(u).pressureValue = slider.value;
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
        //else {
        //    foreach (var u in AirSystem.graphAir.Vertices)
        //    {
        //        if (dfs.VertexColors[u] == GraphColor.Black)
        //        {
        //            airSystem.GetVertexObjectByName(u).isAir = false;
        //            airSystem.GetVertexObjectByName(u).pressureValue = 0;
        //        }
        //    }
        //}

        //foreach (var u in AirSystem.graphAir.Vertices)
        //{
        //    if (dfs.VertexColors[u] == GraphColor.Black)
        //    {
        //        airSystem.GetVertexObjectByName(u).isAir = true;
        //        airSystem.GetVertexObjectByName(u).pressureValue = slider.value;
        //    }
        //    else
        //    {
        //        airSystem.GetVertexObjectByName(u).isAir = false;
        //        airSystem.GetVertexObjectByName(u).pressureValue = 0;
        //    }
        //}

    }

    private void OnDestroy()
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
