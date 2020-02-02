using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGraphicsController : MonoBehaviour
{
    public Animator animator;
    public Animator faceAnimator;
    public bool isCutted;
    public bool isFeellingBad;
    public bool isFeellingSad;
    public SpriteRenderer spriteRenderer;

    public Sprite CuttedSprite;
    public Sprite FeelsBadSprite;
    public Sprite SadSprite;
    public Sprite BadSadSprite;
    public Sprite CuttedSadSprite;
    public Sprite CuttedBadSadSprite;
    public Sprite BothSprite;
    private Sprite _initialSprite;

private void Start() 
{
    _initialSprite = spriteRenderer.sprite;
}

    public void OnSelect() 
    {
        animator.SetTrigger("Selected");       
        faceAnimator.SetTrigger("Selected");       
    }

    public void OnCut()
    {
        animator.SetTrigger("Cut");       
    }

    public void OnUnsetCut()
    {
        animator.SetTrigger("NotCut");       
    }

    public void OnMakeBad()
    {
        animator.SetTrigger("Bad");       
    }

    public void OnUnsetMakeBad()
    {
        animator.SetTrigger("NotBad");       
    }

    public void OnMakeSad()
    {
        animator.SetTrigger("Sad");       
    }

    public void OnUnsetMakeSad()
    {
        animator.SetTrigger("NotSad");       
    }

    public void SetCutted()
    {
        Debug.Log("Set cutted");
        isCutted = true;
        UpdateSprite();
    }

    public void SetBad()
    {
        isFeellingBad = true;
        UpdateSprite();
    }

    public void SetSad()
    {
        isFeellingSad = true;
        UpdateSprite();
    }

    public void UnsetCutted()
    {
        isCutted = false;
        UpdateSprite();
    }

    public void UnsetBad()
    {
        isFeellingBad = false;
        UpdateSprite();
    }

    public void UnsetSad()
    {
        isFeellingSad = false;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        Debug.Log(isCutted + " " + isFeellingBad + " " + isFeellingSad);

        if (isCutted && !isFeellingBad && !isFeellingSad)
            spriteRenderer.sprite = CuttedSprite;
        
        if (!isCutted && isFeellingBad && !isFeellingSad)
            spriteRenderer.sprite = FeelsBadSprite;

        if (!isCutted && !isFeellingBad && isFeellingSad)
            spriteRenderer.sprite = SadSprite != null? SadSprite : _initialSprite;
        
        if(isCutted && isFeellingBad && !isFeellingSad)
            spriteRenderer.sprite = BothSprite != null? BothSprite : _initialSprite;

        if(isCutted && !isFeellingBad && isFeellingSad)
            spriteRenderer.sprite = CuttedSadSprite != null? CuttedSadSprite : _initialSprite;

        if(!isCutted && isFeellingBad && isFeellingSad)
            spriteRenderer.sprite = BadSadSprite != null? BadSadSprite : _initialSprite;

        if(isCutted && isFeellingBad && isFeellingSad)
            spriteRenderer.sprite = CuttedBadSadSprite!= null? CuttedBadSadSprite : _initialSprite;

        if(!isCutted && !isFeellingBad && !isFeellingSad)
            spriteRenderer.sprite = _initialSprite;
    }
}