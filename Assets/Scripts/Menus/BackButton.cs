using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void HandleBackButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
