using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    const string scorePretext = "Score: ";
    float score;
    Text finalScore;

    void Start()
    {
        finalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score = HUD.score;
        finalScore.text = scorePretext + score.ToString();
    }

    public void HandleRetryButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Gameplay);
    }

    public void HandleExitButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
