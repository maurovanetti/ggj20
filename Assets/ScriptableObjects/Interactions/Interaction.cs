using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaction", menuName = "Interaction")]
public class Interaction : ScriptableObject 
{
    public Tool tool;
    public PlantStatus targetStatus;
}