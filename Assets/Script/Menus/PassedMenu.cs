using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassedMenu : MonoBehaviour
{
    private int lifes;

    public void NextLevel(string sceneName)
    {
        GameMenager.PlayerLifes = lifes;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetLifes(int lifes)
    {
        this.lifes = lifes;
    }
}
