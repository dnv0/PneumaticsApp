using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalObject : MonoBehaviour
{
    void Start()
    {
        this.name = AirSystem.pedalCounter + " Pedal ";
        AirSystem.pedalCounter++;
    }
}
