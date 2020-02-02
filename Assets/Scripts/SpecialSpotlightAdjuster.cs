using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpotlightAdjuster : SpotlightAdjuster
{

    public float foregroundFactor;
    public float backgroundFactor;

    protected override void Initialize()
    {
        base.Initialize();
        foregroundVolume *= foregroundFactor;
        backgroundVolume *= backgroundFactor;
    }
}