using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;

    [Header("Audio Sources")]
    public AudioSource CoinSource;
    public AudioSource UISource;

    [Header("Audio Clips")]
    public AudioClip bgMusic;
    public AudioClip[] footstepClips;
    public AudioClip coinSound;
    public AudioClip jumpSound;

    private void Awake()
    {
        am = this;
        PlayBG();
    }

    void PlayBG()
    {
        UISource.clip = bgMusic;
        UISource.volume = 0.8f;
        UISource.Play();
    }

    public void PlaySoundOn(AudioSource audio, AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }

    public void PlayCoinSound()
    {
        PlaySoundOn(CoinSource, coinSound);
    }

    public void PlayFootstepSound(AudioSource audio)
    {
        if (footstepClips.Length > 0)
        {
            PlaySoundOn(audio, GetRandomClip(footstepClips));
        }
    }

    public void PlayJumpSound(AudioSource audio)
    {
        PlaySoundOn(audio, jumpSound);
    }

    public AudioClip GetRandomClip(AudioClip[] clips)
    {
        if (clips.Length > 0)
        {
            return clips[Random.Range(0, clips.Length)];
        }
        return null;
    }
}
