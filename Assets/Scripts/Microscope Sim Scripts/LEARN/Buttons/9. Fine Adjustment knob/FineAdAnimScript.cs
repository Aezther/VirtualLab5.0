using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FineAdAnimScript : MonoBehaviour
{
    public Animator FineAdAnim;
    void Start()
    {
        FineAdAnim = GetComponent<Animator>();
    }
    public void ActivateFineAdKnobAnim()
    {
        FineAdAnim.Play("FineAdAnim");
    }
    public void DisableFineAdKnobAnim()
    {
        FineAdAnim.Play("New State");
    }
    
}
