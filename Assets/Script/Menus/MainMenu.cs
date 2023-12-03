using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    public GameObject SettingsMenu;

    public void ContinueGame()
    {

    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("One");
    }

    public void SttingsMenu()
    {
       SettingsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
