using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Target pointsAddedInvoker;
    static UnityAction<float> pointsAddedListener;

    static Target spawnBallInvoker;
    static UnityAction spawnBallListener;

    static List<SpecialBall> doublePointsInvoker = new List<SpecialBall>();
    static List<UnityAction> doublePointsListener = new List<UnityAction>();

    static List<SpecialBall> freezeTimeInvoker = new List<SpecialBall>();
    static List<UnityAction> freezeTimeListener = new List<UnityAction>();

    static List<SpecialBall> timeAdders = new List<SpecialBall>();
    static List<UnityAction> timeAddingListeners = new List<UnityAction>();

    static List<HUD> gamePausingInvokers = new List<HUD>();
    static List<UnityAction> gamePausers = new List<UnityAction>();

    static List<ResumeButton> gameResumingInvokers = new List<ResumeButton>();
    static List<UnityAction> gameResumers = new List<UnityAction>();

    static SpecialBall soundEffectInvoker;
    static UnityAction<AudioClips> soundEffectListener;

    public static void AddPointInvoker(Target invoker)
    {
        pointsAddedInvoker = invoker;
        if(pointsAddedInvoker != null)
        {
            pointsAddedInvoker.AddPointsAddedListener(pointsAddedListener);
        }
    }

    public static void AddPointListener(UnityAction<float> listener)
    {
        pointsAddedListener = listener;
        if(pointsAddedInvoker != null)
        {
            pointsAddedInvoker.AddPointsAddedListener(pointsAddedListener);
        }
    }

    public static void AddSpawnBallInvoker(Target invoker)
    {
        spawnBallInvoker = invoker;
        if(spawnBallInvoker != null)
        {
            spawnBallInvoker.AddSpawnBallListener(spawnBallListener);
        }
    }

    public static void AddSpawnBallEventListener(UnityAction listener)
    {
        spawnBallListener = listener;
        if(spawnBallInvoker != null)
        {
            spawnBallInvoker.AddSpawnBallListener(spawnBallListener);
        }
    }

    public static void AddDoublePointsInvoker(SpecialBall invoker)
    {
        doublePointsInvoker.Add(invoker);
        foreach(UnityAction listener in doublePointsListener)
        {
            invoker.AddSpeedListener(listener);
        }
    }

    public static void AddDoublePointsListener(UnityAction listener)
    {
        doublePointsListener.Add(listener);
        foreach(SpecialBall specialBall in doublePointsInvoker)
        {
            specialBall.AddSpeedListener(listener);
        }
    }

    public static void AddFreezeTimeInvoker(SpecialBall invoker)
    {
        freezeTimeInvoker.Add(invoker);
        foreach(UnityAction listener in freezeTimeListener)
        {
            invoker.AddFreezeTimeListener(listener);
        }
    }

    public static void AddFreezeTimeEventListener(UnityAction listener)
    {
        freezeTimeListener.Add(listener);
        foreach(SpecialBall invoker in freezeTimeInvoker)
        {
            invoker.AddFreezeTimeListener(listener);
        }
    }

    public static void AddTimeAddingInvoker(SpecialBall invoker)
    {
        timeAdders.Add(invoker);
        foreach(UnityAction listener in timeAddingListeners)
        {
            invoker.AddAdditionalTimeListener(listener);
        }
    }

    public static void AddTimeAddingListener(UnityAction listener)
    {
        timeAddingListeners.Add(listener);
        foreach(SpecialBall invoker in timeAdders)
        {
            invoker.AddAdditionalTimeListener(listener);
        }
    }

    public static void AddGamePausingInvoker(HUD invoker)
    {
        gamePausingInvokers.Add(invoker);
        foreach(UnityAction listener in gamePausers)
        {
            invoker.AddGamePausedEventListener(listener);
        }
    }

    public static void AddGamePausedListener(UnityAction listener)
    {
        gamePausers.Add(listener);
        foreach(HUD invoker in gamePausingInvokers)
        {
            invoker.AddGamePausedEventListener(listener);
        }
    }

    public static void AddGameResumedInvokers(ResumeButton invoker)
    {
        gameResumingInvokers.Add(invoker);
        foreach(UnityAction listener in gameResumers)
        {
            invoker.AddGameResumedEventListener(listener);
        }
    }

    public static void AddGameResumedListeners(UnityAction listener)
    {
        gameResumers.Add(listener);
        foreach(ResumeButton invoker in gameResumingInvokers)
        {
            invoker.AddGameResumedEventListener(listener);
        }
    }

    public static void AddSoundEffectInvoker(SpecialBall invoker)
    {
        soundEffectInvoker = invoker;
        if(invoker != null)
        {
            invoker.AddSoundEffectListener(soundEffectListener);
        }
    }

    public static void AddSoundEffectListener(UnityAction<AudioClips> listener)
    {
        soundEffectListener = listener;
        if(soundEffectInvoker != null)
        {
            soundEffectInvoker.AddSoundEffectListener(listener);
        }
    }
}
