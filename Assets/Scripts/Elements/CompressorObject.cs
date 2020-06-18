using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuickGraph;

public class CompressorObject : MonoBehaviour
{
    private Canvas canv;
    private Slider slider;
    private CreateVertex output;
    public bool status;

    void Start()
    {
        output = GetComponentInChildren<CreateVertex>();

        canv = this.transform.Find("Canvas").GetComponent<Canvas>();
        slider = canv.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        if (slider.value == 1)
        {
            AirSystem.dfs.Compute(output.myVertexName);
        }
        else {
            foreach (var u in AirSystem.graphAir.Vertices)
            {
                AirSystem.dfs.VertexColors[u] = GraphColor.White;
            }
        }

    }
}
