using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightAdjuster : Adjuster
{
    protected float foregroundVolume = +2f;
    protected float backgroundVolume = -15f;

    public void ToForeground()
    {
        ChangeVolume(foregroundVolume);
    }

    public void ToEnsemble()
    {
        ChangeVolume(0);
    }

    public void ToBackground()
    {
        ChangeVolume(backgroundVolume);
    }

    private void ChangeVolume(float decibels)
    {
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat(adjustableMusic.volumeExposedVariable, decibels);
    }
}