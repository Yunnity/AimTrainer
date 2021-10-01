using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    float duration = 60;
    bool started = false;
    bool running = false;
    bool paused = false;
    Timer doubleSpeedTimer;
    Timer pauseTimer;

    public bool isFinished
    {
        get { return started && !running; }
    }

    public bool isRunning
    {
        get { return running; }
    }

    public float Duration
    {
        set
        {
            if(!running)
            {
                duration = value;
            }
        }
        get { return duration; }
    }

    public void Run()
    {
        running = true;
        started = true;
    }

    void Start()
    {
        doubleSpeedTimer = gameObject.AddComponent<Timer>();
        doubleSpeedTimer.Duration = 2.5f;
        pauseTimer = gameObject.AddComponent<Timer>();
        pauseTimer.Duration = 2f;
        EventManager.AddDoublePointsListener(DoubleTime);
        EventManager.AddFreezeTimeEventListener(Pause);
        EventManager.AddTimeAddingListener(AddTime);
    }
    // Update is called once per frame
    void Update()
    {
        if(pauseTimer.isRunning)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }

        if (!paused && running)
        {
            duration -= Time.deltaTime;
            if (doubleSpeedTimer.isRunning)
            {
                duration -= Time.deltaTime;
            }
        }
        if(duration <= 0)
        {
            running = false;
            duration = 60;
        }
    }

    void DoubleTime()
    {
        doubleSpeedTimer.Stop();
        doubleSpeedTimer.Run();
    }

    void Pause()
    {
        pauseTimer.Stop();
        pauseTimer.Run();
    }

    void AddTime()
    {
        duration += 1;
    }
}
