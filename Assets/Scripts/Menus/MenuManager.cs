using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName menuName)
    {
        switch(menuName)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Gameplay:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Help:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.Done:
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}
