using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaturaBambooOnClick : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //change method for the animation
    void Update()
    {
        //change control for the animation
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("selected");
        }
    }
}
