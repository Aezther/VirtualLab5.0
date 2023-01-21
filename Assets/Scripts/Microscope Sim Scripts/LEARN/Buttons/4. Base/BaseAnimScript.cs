using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimScript : MonoBehaviour
{
   public Animator BaseAnim;
    void Start()
    {
        BaseAnim = GetComponent<Animator>();
    }
    public void ActivateBaseAnim()
    {
        BaseAnim.Play("BaseAnim");
    }
    public void DisableBaseAnim()
    {
        BaseAnim.Play("New State");
    }
    
}