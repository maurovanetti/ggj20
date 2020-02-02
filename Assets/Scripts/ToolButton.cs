using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolButton : MonoBehaviour
{
    public Tool tool;
    // public ToolButton OppositeButton;
    public float popUpTime;
    private enum Scaling
    {
        Up,
        Down,
        None
    }
    private Scaling scaling;

    private Image _icon;

    private void Awake() {
        _icon = GetComponentInChildren<Image>();
    }

    public bool CanBeUsed()
    {
        return (scaling != Scaling.None);
    }

    public void ScaleUp() {
        scaling = Scaling.Up;
        transform.localScale = Vector3.zero;
    }

    public void ScaleDown()
    {
        scaling = Scaling.Down;
    }

    public void ScaleToMax()
    {
        transform.localScale = Vector3.one;
        scaling = Scaling.None;
    }

    private Vector3 DeltaScale()
    {
        return Vector3.one * (1f / popUpTime) * Time.deltaTime;
    }

    private void Update()
    {        
        switch (scaling)
        {
            case Scaling.Up:
                transform.localScale += DeltaScale();
                if (transform.localScale.x >= 1f)
                {
                    ScaleToMax();
                }
                break;

            case Scaling.Down:
                transform.localScale -= DeltaScale();
                if (transform.localScale.x <= 0f)
                {
                    scaling = Scaling.None;
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }

    // public void EnableOppositeTool()
    // {
    //     OppositeButton.gameObject.SetActive(true);
    // }
}
