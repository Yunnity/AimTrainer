using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialBall : Target
{
    BallType ballType;
    DoublePointsEvent doublePointsEvent;
    FreezeTimeEvent freezeTimeEvent;
    AddTimeEvent addTimeEvent;
    SoundEffectEvent soundEffectEvent = new SoundEffectEvent();

    public BallType Ball
    {
        set
        {
            ballType = value;
            if (ballType == BallType.Ultra)
            {
                points = 45;
                lifeSpan = 2;
            }
            else if(ballType == BallType.Quick)
            {
                points = 15;
                doublePointsEvent = new DoublePointsEvent();
                EventManager.AddDoublePointsInvoker(this);
                lifeSpan = 2;
            }
            else if(ballType == BallType.Timer)
            {
                points = 15;
                freezeTimeEvent = new FreezeTimeEvent();
                EventManager.AddFreezeTimeInvoker(this);
                lifeSpan = 1.5f;
            }
            else if(ballType == BallType.Master)
            {
                points = 65;
                addTimeEvent = new AddTimeEvent();
                EventManager.AddTimeAddingInvoker(this);
                lifeSpan = 2;
            }
            else if(ballType == BallType.Standard)
            {
                lifeSpan = 1000;
                points = 10;
            }
            EventManager.AddSoundEffectInvoker(this);
        }
    }

    protected override void OnMouseDown()
    {
        if(clickable)
        {
            base.OnMouseDown();
            if(ballType == BallType.Ultra)
            {
                soundEffectEvent.Invoke(AudioClips.Ultra);
            }
            else if (ballType == BallType.Quick)
            {
                doublePointsEvent.Invoke();
                soundEffectEvent.Invoke(AudioClips.Quick);
            }
            else if (ballType == BallType.Timer)
            {
                freezeTimeEvent.Invoke();
                soundEffectEvent.Invoke(AudioClips.Timer);
            }
            else if (ballType == BallType.Master)
            {
                addTimeEvent.Invoke();
                soundEffectEvent.Invoke(AudioClips.Master);
            }
            else if(ballType == BallType.Standard)
            {
                soundEffectEvent.Invoke(AudioClips.Standard);
            }
        }
    }

    public void AddSpeedListener(UnityAction listener)
    {
        doublePointsEvent.AddListener(listener);
    }

    public void AddFreezeTimeListener(UnityAction listener)
    {
        freezeTimeEvent.AddListener(listener);
    }

    public void AddAdditionalTimeListener(UnityAction listener)
    {
        addTimeEvent.AddListener(listener);
    }

    public void AddSoundEffectListener(UnityAction<AudioClips> listener)
    {
        soundEffectEvent.AddListener(listener);
    }
}
