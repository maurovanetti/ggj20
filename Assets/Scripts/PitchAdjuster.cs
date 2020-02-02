using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class PitchAdjuster : Adjuster
{
    public float deltaPitch;
    public float transitionSeconds;    

    protected float? initialPitch;

    private AudioMixer audioMixer;
    private string pitchExposedVariable;

    protected virtual float Pitch
    {
        get
        {
            float pitch;
            if (audioMixer.GetFloat(pitchExposedVariable, out pitch))
            {
                return pitch;
            }
            return 1f;
        }

        set
        {
            if (!audioMixer.SetFloat(pitchExposedVariable, value))
            {
                Debug.LogError(pitchExposedVariable + " not exposed in " + audioMixer.name);
            }
        }
    }

    protected float DeltaPitchPerSecond
    {
        get
        {
            return deltaPitch / transitionSeconds;
        }
    }

    protected override void Initialize()
    {
        this.pitchExposedVariable = adjustableMusic.pitchExposedVariable;
        this.audioMixer = audioSource.outputAudioMixerGroup.audioMixer;
        this.initialPitch = null;
    }

    private void Update()
    {
        CheckInitialPitch();
        Adjust();
        if (ToNormalPitch())
        {
            SetNormalPitch();
            Stop();
        }
        else if (ToWorstPitch())
        {
            SetWorstPitch();
            Stop();
        }
    }

    protected void CheckInitialPitch()
    {
        if (initialPitch == null)
        {
            initialPitch = Pitch;
        }
    }

    protected abstract bool ToNormalPitch();

    protected virtual void SetNormalPitch()
    {
        Pitch = 1f;
    }

    protected abstract bool ToWorstPitch();

    protected abstract void SetWorstPitch();

    protected abstract void Adjust();

    protected void Stop()
    {
        initialPitch = null;
        this.enabled = false;
    }
}
