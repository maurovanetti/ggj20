using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPanel : MonoBehaviour
{
    public Image[] images;
    public float timer;

    private bool _final; 

    // Start is called before the first frame update
    void Start()
    {
        foreach(Image image in images)
        {
            image.enabled = false;
        }
    }

    private void Update() 
    {
        if(_final)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                foreach(Image image in images)
                {
                    image.enabled = false;
                }
            }

            _final = false;
        }
    }

    public void EnableFinalScreenWithDelay()
    {
        _final = true;
    }
}
