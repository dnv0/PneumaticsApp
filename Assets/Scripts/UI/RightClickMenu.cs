using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : MonoBehaviour
{
    public GameObject onElementMenu;
    public GameObject onEdgeMenu;  

    private GameObject currentMenu;
    private GameObject hittedObject;

    void Update()
    {
        // Инициализация raycast
        //
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            // Вызов меню при нажатии ПКМ на элемент
            //
            if (hit.collider.tag.Equals("Element"))
            {
                if (Input.GetMouseButtonDown(1) && !onElementMenu.activeSelf)
                {
                    ShowOnElementMenu();
                    hittedObject = hit.transform.gameObject;
                }
            }

            // Вызов меню при нажатии ПКМ на кабель
            //
            if (hit.collider.tag.Equals("Cable"))
            {
                if (Input.GetMouseButtonDown(1))
                {

                }
            }
        }

        // Удаление текущего контекстного меню при клике за его границами
        //
        if (onElementMenu.activeSelf)
            HideMenuOnClick(onElementMenu);
    }

    // Отображение контекстного меню элемента
    //
    void ShowOnElementMenu()
    {
        currentMenu = onElementMenu;
        
        onElementMenu.SetActive(true);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        onElementMenu.transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Удаление текущего контекстного меню при клике за его границами
    //
    private void HideMenuOnClick(GameObject menu)
    {
        if ((Input.GetMouseButton(0) || Input.GetMouseButton(2)) && !RectTransformUtility.RectangleContainsScreenPoint(menu.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
        {
            menu.SetActive(false);
        }
    }

    // Функция удаления элемента пневмоавтоматики
    //
    public void DeleteElement()
    {
        // Удаление объекта и скрытие меню
        //
        Destroy(hittedObject);
        onElementMenu.SetActive(false);
    }
}
