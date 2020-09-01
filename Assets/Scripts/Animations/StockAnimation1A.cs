using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockAnimation1A : MonoBehaviour
{
    // Инициализация аниматора и вершин цилиндра
    //
    private Animator anim;
    private CreateVertex input;

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
        input = transform.Find("Input").GetComponent<CreateVertex>();
        //

        lastStatus = 0;
    }

    void Update()
    {
        if (input.isAir)
        {
            anim.speed = input.pressureValue / maxPressureValue;
            anim.SetInteger("Status", 1);
        }

        if (!input.isAir)
        {
            anim.speed = 1;
            anim.SetInteger("Status", 2);
        }
    }
}
