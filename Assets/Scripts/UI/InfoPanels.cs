using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanels : MonoBehaviour
{
    public GameObject currentPanel;

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ToggleActive(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MinimizeScreen()
    {
        Screen.fullScreen = false;
    }
}
