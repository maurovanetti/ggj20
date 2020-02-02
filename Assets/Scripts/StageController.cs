using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public PlantController[] plants;
    public GameEvent onStageCleared;

    public void CheckEnsembleStatus()
    {
        // Check all plants are OK
        foreach (PlantController plant in plants)
        {
            if (!plant.IsOk())
            {
                return;
            }
        }
        Debug.Log("Stage Cleared");
        onStageCleared.RaiseEvent();            
    }
}
