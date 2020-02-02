using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Adjuster : MonoBehaviour
{
    public bool setUpPhase;

    protected AudioSource audioSource;
    protected AdjustableMusic adjustableMusic;

    // Start is called before the first frame update
    void Start()
    {
        adjustableMusic = GetComponent<AdjustableMusic>();
        audioSource = GetComponent<AudioSource>();
        Initialize();
    }    

    protected virtual void Initialize()
    {
        // Does nothing
    }

    protected void Sync()
    {
        float t = (Time.time - adjustableMusic.MusicStartTime) % audioSource.clip.length;
        audioSource.timeSamples = Mathf.RoundToInt(t * (float) audioSource.clip.frequency);
    }
}