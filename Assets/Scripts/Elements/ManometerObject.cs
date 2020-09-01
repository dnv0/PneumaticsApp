using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManometerObject : MonoBehaviour
{
    public GameObject arrow;

    // Инициализация вершины манометра
    //
    private CreateVertex input;

    private float minAngle = 60f;
    private float maxAngle = 300f;
    private float desiredPosition;

    private float currentPressure;

    private float lerpValue;

    // Start is called before the first frame update
    void Start()
    {
        // Получение вершины
        //
        input = GetComponentInChildren<CreateVertex>();

        desiredPosition = minAngle - maxAngle;
        lerpValue = (minAngle - (currentPressure / 8) * desiredPosition);
    }

    // Update is called once per frame
    void Update()
    {
        currentPressure = input.pressureValue;

        RotateArrow();
    }

    private void RotateArrow()
    {
        float temp = currentPressure / 8;


        lerpValue = Mathf.Lerp(lerpValue, (minAngle - temp * desiredPosition), Time.deltaTime * 2);

        arrow.transform.eulerAngles = new Vector3(180, 0, lerpValue);

    }

}
