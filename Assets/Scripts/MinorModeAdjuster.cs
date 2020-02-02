using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorModeAdjuster : ModeAdjuster
{
    private void Update()
    {
        SetMode(false);
        this.enabled = false;
    }
}