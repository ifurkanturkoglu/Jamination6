using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;

    bool infoPanelIsOpen;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void InfoPanel()
    {
        infoPanelIsOpen = !infoPanelIsOpen;
        infoPanel.SetActive(infoPanelIsOpen);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
