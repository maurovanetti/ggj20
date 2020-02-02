using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantStatus", menuName = "PlantStatus")]
[System.Serializable]
public class PlantStatus : ScriptableObject 
{
    public Interaction[] interactions;
}
