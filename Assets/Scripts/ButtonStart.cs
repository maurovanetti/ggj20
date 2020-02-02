using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonStart : MonoBehaviour
{
    public Button button;
    public GameEvent onStart;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        onStart.RaiseEvent();
    }

}
