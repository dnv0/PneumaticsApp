using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVertex : MonoBehaviour
{
    public String value { get; set; }

    public int x { get; set; }
    public int y { get; set; }

    public CustomVertex(String value)
    {
        this.value = value;
        this.x = 0;
        this.y = 0;
    }

    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        CustomVertex other_cast = other as CustomVertex;
        if ((System.Object)other_cast == null)
            return false;

        return this.value == other_cast.value;
    }

    public bool Equals(CustomVertex other)
    {
        if ((object)other == null)
            return false;

        return this.value == other.value;
    }

    public override int GetHashCode()
    {
        return this.value.GetHashCode();
    }

    public override string ToString()
    {
        return this.value;
    }
}
