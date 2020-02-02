using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomly : MonoBehaviour
{

    public float maxRotation;
    public float nervousness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float perlin = Mathf.PerlinNoise(Time.time * nervousness, transform.position.y) - 0.5f;
        transform.rotation = Quaternion.Euler(0, 0, perlin * maxRotation * 2);
    }
}
