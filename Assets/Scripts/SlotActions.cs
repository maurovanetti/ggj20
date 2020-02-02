using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotActions : MonoBehaviour
{
    public Sprite imageIcon;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = imageIcon;
    }

    public void fill(Sprite icon)
    {
        //fill icon tools based on plants
        //ActivePlant.Value.gameObject.name
        gameObject.GetComponent<Image>().sprite = imageIcon;
    }

    public void shrink()
    {
        Destroy(gameObject);
    }
}
