using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("Music InGame")]
    public AudioClip[] Music;
    public float MusicVolume;
    [Header("SFX InGame")]
    public AudioClip[] SFX;
    public float SFXVolume;
    [Header("Outputs")]
    public AudioSource[] Sources;
    public static AudioManager Instance;
    private bool IsCheck;
    private int Queue;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (IsCheck)
        {
            CheckMusic();
        }
    }

    public void PlaySFX(int i)
    {
        if (!GameState.Instance.EasterEgg)
        {
            Sources[1].clip = SFX[i];
        }
        else
        {
            Sources[1].clip = SFX[2];
        }
        Sources[1].Play();
    }

    public void PlayMusic(int i)
    {
        if (i == 0)
        {
            StartPlaying(i);
            Queue = 0;
        }
        else
        {
            if (Queue == 0)
            {
                StartPlaying(i);
                Queue = i;
            }
            else
            {
                Queue = i;
                IsCheck = true;
            }
        }
    }

    public void CheckMusic()
    {
        if (Sources[0].time <= 0.05f)
        {
            StartPlaying(Queue);
            IsCheck = false;
        }
    }

    public void StartPlaying(int i)
    {
        Sources[0].clip = Music[i];
        Sources[0].Play();
    }
}

