using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added

public class OpenClose : MonoBehaviour
{
    
    private Slider mSlider; //reference of slider
    public GameObject Box; //reference of the game object with animator
    void Start()
    {
        mSlider = GetComponent<Slider>();
    }

    public void ApplyAnimation()
    {
        if (Box != null)
        {
            Animator animator = Box.GetComponent<Animator>();
            if (animator)
            {
                animator.SetFloat("OpenCloseValue", mSlider.value);
            }

        }
    }
}
