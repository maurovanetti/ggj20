using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LowerTempoAdjuster : TempoAdjuster
{
    public float tempoFactor;

    protected override void AdjustTargetTempo()
    {
        targetTempo = audioSource.pitch / tempoFactor;
        if (targetTempo < 1f)
        {
            Debug.LogError("Should not set the target tempo below 1, currently it is " + targetTempo);
            targetTempo = 1f;
        }
    }
}
