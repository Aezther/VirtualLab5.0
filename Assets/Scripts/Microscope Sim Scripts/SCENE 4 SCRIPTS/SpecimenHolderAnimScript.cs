using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenHolderAnimScript : MonoBehaviour
{
    public Animator SpecimenHolderAnim;
    void Start()
    {
        SpecimenHolderAnim = GetComponent<Animator>();
    }
    public void ActivateSpeciHolderAnim()
    {
        SpecimenHolderAnim.Play("SpeciHolderAnim");
    }
    public void DisableSpeciHolderAnim()
    {
        SpecimenHolderAnim.Play("New State");
    }
    
}
