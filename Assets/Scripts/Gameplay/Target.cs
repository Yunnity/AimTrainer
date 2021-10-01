using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    protected float points;
    protected float lifeSpan;
    PointsAddedEvent pointsAddedEvent;
    SpawnBallEvent spawnBallEvent;
    Timer lifeSpanTimer;
    protected bool clickable = true;

    protected virtual void Start()
    {
        pointsAddedEvent = new PointsAddedEvent();
        spawnBallEvent = new SpawnBallEvent();
        EventManager.AddPointInvoker(this);
        EventManager.AddSpawnBallInvoker(this);
        lifeSpanTimer = gameObject.AddComponent<Timer>();
        lifeSpanTimer.Duration = lifeSpan;
        lifeSpanTimer.Run();
        EventManager.AddGamePausedListener(PauseGame);
        EventManager.AddGameResumedListeners(ResumeGame);
    }

    void Update()
    {
        if (lifeSpanTimer.isFinished)
        {
            Destroy(gameObject);
            spawnBallEvent.Invoke();
        }
    }

    protected virtual void OnMouseDown()
    {
        if(clickable)
        {
            pointsAddedEvent.Invoke(points);
            Destroy(gameObject);
            spawnBallEvent.Invoke();
        }
    }

    public void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    public void AddSpawnBallListener(UnityAction listener)
    {
        spawnBallEvent.AddListener(listener);
    }

    void PauseGame()
    {
        clickable = false;
    }

    void ResumeGame()
    {
        clickable = true;
    }
}
