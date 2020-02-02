using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerTempoPitchAdjuster : RaisePitchAdjuster
{
    protected override float Pitch
    {
        get
        {            
            return base.Pitch;
        }

        set
        {
            base.Pitch = value;
            audioSource.pitch = 1 / value;
        }
    }
}
