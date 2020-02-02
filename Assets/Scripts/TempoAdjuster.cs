using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class TempoAdjuster : Adjuster
{
    protected float targetTempo;

    void Update()
    {
        AdjustTargetTempo();        
        if (targetTempo <= 1f)
        {
            targetTempo = 1f;
            Sync();            
        }
        audioSource.pitch = targetTempo;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat(adjustableMusic.pitchExposedVariable, 1f / targetTempo);
        this.enabled = false;
    }

    protected abstract void AdjustTargetTempo();
}
