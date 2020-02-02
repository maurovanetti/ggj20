using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteRemover : MonoBehaviour
{
    public Parasites parasites;

    private void Start()
    {
        // Does nothing
    }

    private void Update()
    {
        parasites.Decrease();
        enabled = false;
    }
}