using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    //public float dragSpeed = 2;
    //private Vector3 dragOrigin;


    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        dragOrigin = Input.mousePosition;
    //        return;
    //    }

    //    if (!Input.GetMouseButton(0)) return;

    //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //    Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed);

    //    transform.Translate(move, Space.World);
    //}

    private float dist;
    private Vector3 MouseStart, MouseMove;
    private Vector3 derp;

    void Start()
    {
        dist = transform.position.z;  // Distance camera is above map
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        }
        else if (Input.GetMouseButton(2))
        {
            MouseMove = new Vector3(MouseStart.x - Input.mousePosition.x , MouseStart.y - Input.mousePosition.y, dist);
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            transform.position = new Vector3(transform.position.x + MouseMove.x * Time.deltaTime, transform.position.y + MouseMove.y * Time.deltaTime, dist);
        }
    }
}
