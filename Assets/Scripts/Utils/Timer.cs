using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float duration;
    float elapsedSeconds = 0;
    bool started = false;
    bool running = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            elapsedSeconds += Time.deltaTime;
            if(elapsedSeconds >= duration)
            {
                running = false;
                elapsedSeconds = 0;
            }
        }
    }

    public void Run()
    {
        // only run with valid duration
        if (duration > 0)
        {
            running = true;
            started = true;
            elapsedSeconds = 0;
        }
    }

    public void Stop()
    {
        running = false;
        started = false;
        elapsedSeconds = 0;
    }
}
