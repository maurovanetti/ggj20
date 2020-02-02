using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodQualityAdjuster : QualityAdjuster
{
    private void Update()
    {
        SetQuality(true);
        this.enabled = false;
    }
}