using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public PlantControllerVariable activePlant;
    public InteractionUsedVariable interactionUsed;
    public GameEvent onToolUsed;

    public GameObject ghostImage;
    public Interaction interaction;

    public float speed;
    public float destructionDistance;
    private SpriteRenderer _ghost;
    private Vector2 _initialPosition;
    private bool _isReset;

    private void Update()
    {
        if(_isReset)
        {
            Vector2 direction = _initialPosition - (Vector2)_ghost.transform.position;
            _ghost.transform.Translate(direction * speed * Time.deltaTime);

            if (Vector3.Distance(_ghost.transform.position, _initialPosition) <= destructionDistance)
            {
                Destroy(_ghost.gameObject);
                _isReset = false;
                
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _ghost = Instantiate(ghostImage.GetComponent<SpriteRenderer>());
        Sprite thisSprite = GetComponent<Image>().sprite;
        _ghost.sprite = GetComponent<Image>().sprite;

    }

    public void OnDrag(PointerEventData eventData)
    {
        _ghost.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject == activePlant.Value.gameObject)
            {
                //add interaction
                Debug.Log("Active plant hit by " + interaction.tool.name + " (" + interaction.name + ")");
                interactionUsed.Value = interaction;
                onToolUsed.RaiseEvent();
            }
        }

        _isReset = true;
    }
}