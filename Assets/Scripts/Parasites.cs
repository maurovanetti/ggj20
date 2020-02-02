using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasites : MonoBehaviour
{
    public string volumeExposedVariable;
    protected AudioSource audioSource;
    
    public int decibelsPerParasite;

    protected int count;

    public void Increase()
    {
        count++;
    }

    public void Decrease()
    {
        if (count > 0)
        {
            count--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;

    }

    private void Update()
    {
        if (count == 0)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
            audioSource.outputAudioMixerGroup.audioMixer.SetFloat(volumeExposedVariable, count);
        }
    }
}
