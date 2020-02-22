using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompressorObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.name = AirSystem.compressorCounter + " Compressor ";
        AirSystem.compressorCounter++;
    }

    public void ToggleAir()
    {
        CreateVertex obj = GetComponentInChildren<CreateVertex>();
        obj.isAir = !obj.isAir;
    }
}
