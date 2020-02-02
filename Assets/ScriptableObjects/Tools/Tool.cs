using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Tool", order = 0)]
public class Tool : ScriptableObject 
{
    //audioclip?? -> quando viene rilasciato sulla pianta
    //particle? -> quando viene rilasciato sulla pianta

    public Sprite icon;
    public enum AdjusterType
    {
        RaisePitch,
        LowerPitch,
        RaiseTempo,
        LowerTempo,
        MajorMode,
        MinorMode,
        GoodQuality,
        BadQuality,
        ParasitesRemover
    }
    public AdjusterType adjusterType;


    public Type GetAdjusterType()
    {
        switch (adjusterType)
        {
            case AdjusterType.RaisePitch:
                return typeof(RaisePitchAdjuster);

            case AdjusterType.LowerPitch:
                return typeof(LowerPitchAdjuster);

            case AdjusterType.RaiseTempo:
                return typeof(RaiseTempoAdjuster);

            case AdjusterType.LowerTempo:
                return typeof(LowerTempoAdjuster);

            case AdjusterType.MajorMode:
                return typeof(MajorModeAdjuster);

            case AdjusterType.MinorMode:
                return typeof(MinorModeAdjuster);

            case AdjusterType.GoodQuality:
                return typeof(GoodQualityAdjuster);

            case AdjusterType.BadQuality:
                return typeof(BadQualityAdjuster);

            case AdjusterType.ParasitesRemover:
            default:
                return typeof(ParasiteRemover);
        }
    }

}
