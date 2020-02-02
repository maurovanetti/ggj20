using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Animator[] animators;
    public bool Select;
    public bool Cut;
    public bool Bad;
    public bool Sad;

    private void Update()
    {
        if (Select)
        {
            foreach (var animator in (animators))
            {
                animator.SetTrigger(("Selected"));
            }

            Select = false;
        }
        
        if (Bad)
        {
            foreach (var animator in (animators))
            {
                animator.SetTrigger(("Bad"));
            }

            Bad = false;
        }
        
        if (Cut)
        {
            foreach (var animator in (animators))
            {
                animator.SetTrigger(("Cut"));
            }

            Cut = false;
        }

                if (Sad)
        {
            foreach (var animator in (animators))
            {
                animator.SetTrigger(("Sad"));
            }

            Sad = false;
        }
    }
}
