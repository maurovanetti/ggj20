using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RaiseTempoAdjuster : TempoAdjuster
{
    public float tempoFactor;

    protected override void AdjustTargetTempo()
    {
        targetTempo = audioSource.pitch * tempoFactor;
    }
}
