using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ToolContainer : MonoBehaviour
{
    public PlantControllerVariable ActivePlant;
    public ToolButton[] toolButtons;
    private Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    public void OnStatusUpdate()
    {
        if (ActivePlant.Value != null)
        {
            ShowTools();
        }
        else
        {
            HideTools();
        }
    }

    public void ShowTools()
    {
        //Add show logic
        List<Interaction> interactionsToShow =  ActivePlant.Value.AvailableInteractions();
        foreach (ToolButton toolButton in toolButtons)
        {
            Interaction interaction = null;
            foreach (Interaction interactionToShow in interactionsToShow)
            {
                if (interactionToShow.tool == toolButton.tool)
                {
                    interaction = interactionToShow;
                    break;
                }
            }
            if (interaction != null)
            {
                toolButton.gameObject.SetActive(true);
                toolButton.GetComponentInChildren<ItemDragHandler>().interaction = interaction;
                if (_animator.GetBool("Show"))
                {
                    toolButton.ScaleUp();
                }
                else
                {
                    toolButton.ScaleToMax();
                }
            }
            else
            {
                if (_animator.GetBool("Show"))
                {
                    toolButton.ScaleDown();
                }
            }            
        }
        _animator.SetBool("Show", true);
    }

        public void HideTools()
    {
        //Add show logic
        Debug.Log("Hide tool container ");
        _animator.SetBool("Show", false);
    }

    public void OnEndHideAnimation()
    {
        //reset tools 
        foreach (ToolButton toolButton in toolButtons)
        {
            toolButton.gameObject.SetActive(false);
        }
    }
}