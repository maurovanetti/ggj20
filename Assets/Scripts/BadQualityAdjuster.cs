using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadQualityAdjuster : QualityAdjuster
{
    private void Update()
    {
        SetQuality(false);
        this.enabled = false;
    }
}