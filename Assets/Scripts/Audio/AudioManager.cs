using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClips, AudioClip> audioClips = new Dictionary<AudioClips, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClips.Standard, Resources.Load<AudioClip>("hitmarker"));
        audioClips.Add(AudioClips.Ultra, Resources.Load<AudioClip>("dsr"));
        audioClips.Add(AudioClips.Timer, Resources.Load<AudioClip>("pause"));
        audioClips.Add(AudioClips.Quick, Resources.Load<AudioClip>("fast"));
        audioClips.Add(AudioClips.Master, Resources.Load<AudioClip>("oneup"));
        EventManager.AddSoundEffectListener(PlayAudioClip);
    }

    static void PlayAudioClip(AudioClips clipName)
    {
        audioSource.PlayOneShot(audioClips[clipName]);
    }
}
