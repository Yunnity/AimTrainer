using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject resumeButton;
    float radius;

    void Start()
    {
        Time.timeScale = 0;
        GameObject tempButton = Instantiate(resumeButton, transform.position, Quaternion.identity);
        radius = tempButton.GetComponent<CircleCollider2D>().radius;
        Destroy(tempButton);
    }

    public void HandleResumeButtonClicked()
    {
        Destroy(gameObject);
        if(GameObject.FindGameObjectWithTag("ResumeButton") == null)
        {
            SpawnResumeButton();
        }
    }

    public void HandleQuitButtonClicked()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    void SpawnResumeButton()
    {
        float xSpawn = ScreenUtils.ScreenLeft + radius;
        float ySpawn = ScreenUtils.ScreenBottom + radius;
        float xMiddle = ScreenUtils.ScreenRight / 2;
        float yMiddle = ScreenUtils.ScreenTop / 2;
        int leftCount = 0;
        int botCount = 0;
        GameObject[] currTargets = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in currTargets)
        {
            if(ball.transform.position.x < xMiddle)
            {
                leftCount++;
            }
            if(ball.transform.position.y < yMiddle)
            {
                botCount++;
            }
        }
        if(leftCount >= 2)
        {
            xSpawn = ScreenUtils.ScreenRight - radius;
        }
        if(botCount >= 2)
        {
            ySpawn = ScreenUtils.ScreenTop - radius;
        }
        Instantiate(resumeButton, new Vector3(xSpawn, ySpawn, -Camera.main.transform.position.y), Quaternion.identity);
    }
}
