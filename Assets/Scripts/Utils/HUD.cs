using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreDisplay;
    [SerializeField]
    Text timeDisplay;

    Stopwatch stopWatch;
    Timer doublePointsTimer;
    string preText = "Score: ";
    public static float score = 0;
    float screenClickDeductedPoints = 5;
    PointsDeductedEvent pointsDeductedEvent;
    GamePausedEvent gamePausedEvent;
    bool clickable = true;

    // Start is called before the first frame update
    void Start()
    {
        stopWatch = gameObject.AddComponent<Stopwatch>();
        stopWatch.Run();
        doublePointsTimer = gameObject.AddComponent<Timer>();
        doublePointsTimer.Duration = 5;
        scoreDisplay.text = preText + score.ToString();
        EventManager.AddPointListener(AddScore);
        pointsDeductedEvent = new PointsDeductedEvent();
        AddPointsDeductedListener(DeductScore);
        EventManager.AddDoublePointsListener(DoublePointsOn);
        gamePausedEvent = new GamePausedEvent();
        EventManager.AddGamePausingInvoker(this);
        EventManager.AddGamePausedListener(GamePaused);
        EventManager.AddGameResumedListeners(GameResumed);
    }

    public void AddPointsDeductedListener(UnityAction<float> listener)
    {
        pointsDeductedEvent.AddListener(listener);
    }

    void AddScore(float points)
    {
        if(doublePointsTimer.isRunning)
        {
            score += points * 2;
        }
        else
        {
            score += points;
        }
        scoreDisplay.text = preText + score.ToString();
    }

    void DeductScore(float points)
    {
        if(clickable)
        {
            if (doublePointsTimer.isRunning)
            {
                score -= points * 2;
            }
            else
            {
                score -= points;
            }
            scoreDisplay.text = preText + score.ToString();
        }
        
    }

    void Update()
    {
        if (stopWatch.isFinished)
        {
            MenuManager.GoToMenu(MenuName.Done);
        }

        timeDisplay.text = ((int)(stopWatch.Duration)).ToString();
        if(Input.GetMouseButtonDown(0))
        {
            pointsDeductedEvent.Invoke(screenClickDeductedPoints);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("PauseMenu") == null)
        {
            GameObject resumeButton = GameObject.FindGameObjectWithTag("ResumeButton");
            if(resumeButton != null)
            {
                Destroy(resumeButton);
            }
            MenuManager.GoToMenu(MenuName.Pause);
            gamePausedEvent.Invoke();
        }
    }
    
    void DoublePointsOn()
    {
        doublePointsTimer.Run();
    }

    public void AddGamePausedEventListener(UnityAction listener)
    {
        gamePausedEvent.AddListener(listener);
    }

    void GamePaused()
    {
        clickable = false;
    }

    void GameResumed()
    {
        clickable = true;
        if (doublePointsTimer.isRunning)
        {
            score += 10;
        }
        else
        {
            score += 5;
        }
    }
}
