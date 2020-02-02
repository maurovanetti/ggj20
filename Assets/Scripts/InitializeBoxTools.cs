using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeBoxTools : MonoBehaviour
{
    public GameObject slots;
    public GameObject slotPrefab;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slots.transform) as GameObject;
        }
    }

}
