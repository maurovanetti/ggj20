using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReplaceTrackAdjuster : Adjuster
{
    protected AudioClip defaultClip;
    protected AudioClip alternateClip;

    protected override void Initialize()
    {
        defaultClip = adjustableMusic.DefaultClip;
        alternateClip = GetAlternateClip();
    }

    protected abstract AudioClip GetAlternateClip();

    public void UseDefaultClip()
    {
        UseClip(defaultClip);
    }

    public void UseAlternateClip()
    {
        UseClip(alternateClip);
    }

    protected void UseClip(AudioClip clip)
    {
        Debug.Log("Replace current track with " + clip.name);
        audioSource.clip = clip;
        audioSource.Play();
        Sync();     
    }
}