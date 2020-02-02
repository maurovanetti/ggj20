using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 _initialPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _initialPosition = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = _initialPosition;
    }
}
