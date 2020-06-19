using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectionSystem : MonoBehaviour
{
    public GameObject lightObject;

    private GameObject currentLight;

    private void Start()
    {
        currentLight = Instantiate(lightObject);
        currentLight.GetComponent<Light>().enabled = false;

        Debug.Log("LghtObject: " + currentLight.name);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (hit.collider.tag.Equals("Vertex") && selection.GetComponent<CreateVertex>().isCabled == false)
            {
                currentLight.GetComponent<Light>().enabled = true;
                currentLight.transform.position = new Vector3(selection.position.x, selection.position.y, selection.position.z - 0.1f);
            }
            else currentLight.GetComponent<Light>().enabled = false;

            if (hit.collider.tag.Equals("Element"))
            {

            }
                
        }
    }
}
