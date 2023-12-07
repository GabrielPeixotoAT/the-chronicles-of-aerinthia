using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public static float Volume = 0.5f;
    public static int PlayerLifes = 3;
    public static bool IsPaused;

    public GameObject PauseMenu;

    private GameObject pauseMenuInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                pauseMenuInstance = Instantiate(PauseMenu, gameObject.transform);
                PauseGame();
            }
            else
            {
                Destroy(pauseMenuInstance);
                ContinueGame();
            }
        }
    }

    public static void ContinueGame()
    {
        IsPaused = false;
        Time.timeScale = 1.0f;
    }

    public static void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }
}
