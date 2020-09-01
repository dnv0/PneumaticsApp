using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickGraph;

public class StockAnimation2A : MonoBehaviour
{
    // Инициализация аниматора и вершин цилиндра
    //
    private Animator anim;
    private CreateVertex input1, input2;

    // Переменная для сохранения последнего состояния анимации
    // Необходима для предотвращения повторного запуска одной и той же анимации, в противном случае шток будет дергаться
    //
    private int lastStatus;

    private float maxPressureValue = 8;

    void Start()
    {
        // Получение компонентов вершин и аниматора
        //
        anim = GetComponent<Animator>();
        input1 = transform.Find("Input 1").GetComponent<CreateVertex>();
        input2 = transform.Find("Input 2").GetComponent<CreateVertex>();
        //

        lastStatus = 0;
    }

    void Update()
    {

        if ((!input1.isAir && !input2.isAir) || (input1.isAir && input2.isAir))
        {
            anim.SetInteger("Status", 0);
        }

        if (input1.isAir)
        {
            if (lastStatus != 1)
            {
                anim.SetInteger("Status", 1);
                lastStatus = 1;

                anim.speed = input1.pressureValue / maxPressureValue;
            }
        }

        if (input2.isAir)
        {
            if (lastStatus != 2)
            {
                anim.SetInteger("Status", 2);
                lastStatus = 2;

                anim.speed = input2.pressureValue / maxPressureValue;
            }

        }
    }
}
