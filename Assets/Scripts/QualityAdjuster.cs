using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QualityAdjuster : ReplaceTrackAdjuster
{
    protected override AudioClip GetAlternateClip()
    {
        return adjustableMusic.alternateQualityClip;
    }

    public void SetQuality(bool good)
    {        
        if (good == adjustableMusic.isGood)
        {
            UseDefaultClip();
        }
        else
        {
            UseAlternateClip();
        }
    }
}