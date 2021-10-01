using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResumeButton : MonoBehaviour
{
    GameResumedEvent gameResumedEvent;

    void Start()
    {
        gameResumedEvent = new GameResumedEvent();
        EventManager.AddGameResumedInvokers(this);
    }
    void OnMouseDown()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        gameResumedEvent.Invoke();
    }

    public void AddGameResumedEventListener(UnityAction listener)
    {
        gameResumedEvent.AddListener(listener);
    }
}
