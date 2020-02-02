using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantController : MonoBehaviour
{
    public PlantControllerVariable activePlant;
    public InteractionUsedVariable interactionUsed;
    public GameEvent onPlantSelected;
    public GameEvent onToolUsed;
    public GameEvent onUpdateStatus;    

    public List<PlantStatus> currentStatuses;
    public List<PlantStatus> correctStatuses;

    private Animator _animator;
    private AudioSource _audioSource;
    private GameObject celebration;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        foreach (Transform child in transform)
        {
            if (child.name == "Celebration")
            {
                celebration = child.gameObject;
                break;
            }
        }
                
    }

    //call when plant is selected/deselected
    public void TogglePlant()
    {
        celebration.SetActive(false);
        SpotlightAdjuster spotlightAdjuster = GetComponentInChildren<SpotlightAdjuster>();
        if (activePlant.Value == null)
        {
            //Deselect all plant logic
            Debug.Log("Deselect " + gameObject.name + " (back to normal)");
            spotlightAdjuster.ToEnsemble();
        }
        else if (activePlant.Value == this)
        {
            //Select plant logic
            Debug.Log("Select " + gameObject.name);
            spotlightAdjuster.ToForeground();
        }
        else
        {
            //Deselect plant logic
            Debug.Log("Deselect " + gameObject.name);
            spotlightAdjuster.ToBackground();
        }
    }

    public List<Interaction> AvailableInteractions()
    {
        List<Interaction> interactions = new List<Interaction>();
        foreach (PlantStatus status in currentStatuses)
        {
            foreach (Interaction interaction in status.interactions)
            {
                interactions.Add(interaction);
            }            
        }
        return interactions;
    }

    public void ApplyUsedTool()
    {
        if (activePlant.Value == this) {
            Interaction interaction = interactionUsed.Value;
            Type adjusterType = interaction.tool.GetAdjusterType();
            Adjuster adjuster = (Adjuster) GetComponentInChildren(adjusterType);
            adjuster.enabled = true;

            List<PlantStatus> statusesToRemove = new List<PlantStatus>();
            foreach (PlantStatus status in currentStatuses)
            {
                foreach (Interaction possibleInteraction in status.interactions)
                {
                    if (interaction == possibleInteraction)
                    {
                        statusesToRemove.Add(status);                        
                    }
                }                
            }
            foreach (PlantStatus statusToRemove in statusesToRemove)
            {
                currentStatuses.Remove(statusToRemove);
            }
            currentStatuses.Add(interaction.targetStatus);
            if (IsOk())
            {
                Celebrate();
            }
            onUpdateStatus.RaiseEvent();
        }
    }

    private void Celebrate()
    {
        celebration.SetActive(true);
    }

    public bool IsOk()
    {
        foreach (PlantStatus correctStatus in correctStatuses)
        {
            if (!currentStatuses.Contains(correctStatus))
            {
                return false;
            }
        }
        return true;
    }
}