using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public PlantControllerVariable activePlant;
    public GameEvent onPlantSelected;
    public GameEvent onStatusUpdated;
    public GraphicRaycaster graphicRaycaster;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!TouchedOnUI())
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    
                if(hit.collider != null)
                {
                    if(hit.collider.gameObject.tag == "Plant")
                    {
                        PlantController selectedPlant = hit.collider.gameObject.GetComponent<PlantController>();

                        if(selectedPlant == activePlant.Value)
                            activePlant.Value = null;
                        else
                            activePlant.Value = selectedPlant;
                    }

                    else
                        activePlant.Value = null;
                }

                else
                    activePlant.Value = null;
                
                onPlantSelected.RaiseEvent();
                onStatusUpdated.RaiseEvent();
            }
        }
    }

    private bool TouchedOnUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}