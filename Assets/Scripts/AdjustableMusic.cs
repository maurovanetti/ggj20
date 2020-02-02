using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableMusic : MonoBehaviour
{
    private const float Delay = 2f;
    private static float endOfDelay = float.MaxValue;
    private bool delaying = true;

    public string pitchExposedVariable;
    public string volumeExposedVariable;
    public bool isMajor;
    public bool isGood;
    public AudioClip alternateModeClip;
    public AudioClip alternateQualityClip;

    private AudioSource audioSource;
    private AudioClip defaultClip;
    public AudioClip DefaultClip
    {
        get { return defaultClip; }
    }

    private float musicStartTime = float.MaxValue;    
    public float MusicStartTime
    {
        get { return musicStartTime; }
    }

    private void Start()
    {
        endOfDelay = Time.time + Delay;
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
        defaultClip = audioSource.clip;
    }

    private void Update()
    {
        if (delaying && Time.time > endOfDelay)
        {
            delaying = false;
            audioSource.mute = false;
            audioSource.Play();
            musicStartTime = Time.time;
        }
    } 
}
