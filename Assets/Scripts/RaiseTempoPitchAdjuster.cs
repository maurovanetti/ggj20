using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseTempoPitchAdjuster : LowerPitchAdjuster
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
