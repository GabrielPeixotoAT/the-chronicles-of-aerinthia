using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text StatusLabel;

    [Header("Menus")]
    public GameObject SettingsMenu;

    void Awake()
    {
        StatusLabel.text = "The Chronicles of Aerinthia\n" +
            $"Versão: {PlayerSettings.bundleVersion}";
    }

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
