using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModeAdjuster : ReplaceTrackAdjuster
{
    protected override AudioClip GetAlternateClip()
    {
        return adjustableMusic.alternateModeClip;
    }

    public void SetMode(bool major)
    {        
        if (major == adjustableMusic.isMajor)
        {
            UseDefaultClip();
        }
        else
        {
            UseAlternateClip();
        }
    }
}