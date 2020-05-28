using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalObject : MonoBehaviour
{
    private string _input;
    private string _output;

    void Start()
    {
        GameObject vertex1 = this.gameObject.transform.GetChild(0).gameObject;
        GameObject vertex2 = this.gameObject.transform.GetChild(1).gameObject;

        _input = vertex1.GetComponent<CreateVertex>().myVertexName;
        _output = vertex2.GetComponent<CreateVertex>().myVertexName;

        this.name = AirSystem.pedalCounter + " Pedal ";
        AirSystem.pedalCounter++;
    }

    void ToggleConnection()
    {

    }
}
