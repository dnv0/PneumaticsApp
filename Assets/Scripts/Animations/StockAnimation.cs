using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickGraph;

public class StockAnimation : MonoBehaviour
{
    // Инициализация аниматора и вершин цилиндра
    //
    private Animator anim;
    private CreateVertex input1, input2;

    // Переменная для сохранения последнего состояния анимации
    // Необходима для предотвращения повторного запуска одной и той же анимации, в противном случае шток будет дергаться
    //
    private int lastStatus;

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
        // Получение цветов вершин цилиндра
        // Белый - нет воздуха, черный - есть воздух
        //
        GraphColor colorInput1 = AirSystem.dfs.VertexColors[input1.myVertexName];
        GraphColor colorInput2 = AirSystem.dfs.VertexColors[input2.myVertexName];
        //

        if(colorInput1 == GraphColor.Black)
        {
            if(lastStatus != 1)
            {
                anim.SetInteger("Status", 1);
                lastStatus = 1;
            }
        }

        if(colorInput2 == GraphColor.Black)
        {
            if(lastStatus != 2)
            {
                anim.SetInteger("Status", 2);
                lastStatus = 2;
            }

        }

        if((colorInput1 == GraphColor.White && colorInput2 == GraphColor.White) || (colorInput1 == GraphColor.Black && colorInput2 == GraphColor.Black))
        {
            anim.SetInteger("Status", 0);
        }
    }
}
