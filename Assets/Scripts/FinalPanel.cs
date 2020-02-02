using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPanel : MonoBehaviour
{
    public Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Image image in images)
        {
            image.enabled = false;
        }
    }
}
