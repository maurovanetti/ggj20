using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorModeAdjuster : ModeAdjuster
{
    private void Update()
    {
        SetMode(true);
        this.enabled = false;
    }
}