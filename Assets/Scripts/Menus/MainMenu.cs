using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Gameplay);
    }

    public void HandleHelpButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void HandleQuitButtonClicked()
    {
        Application.Quit();
    }
}
