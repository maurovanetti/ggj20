using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPitchAdjuster : PitchAdjuster
{

    protected override bool ToNormalPitch()
    {
        return (initialPitch > 1f && Pitch < 1f);
    }

    protected override bool ToWorstPitch()
    {
        return (initialPitch <= 1f && Pitch < (1f - deltaPitch));
    }

    protected override void SetWorstPitch()
    {
        Pitch = 1f - deltaPitch;
    }

    protected override void Adjust()
    {
        Pitch -= DeltaPitchPerSecond * Time.deltaTime;
    }
}
