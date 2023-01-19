using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoarseAdAnimScript : MonoBehaviour
{
    public Animator CoarseAdAnim;
    void Start()
    {
        CoarseAdAnim = GetComponent<Animator>();
    }
    public void ActivateCoarseAdAnim()
    {
        CoarseAdAnim.Play("CoarseAdAnim");
    }
    public void DisableCoarseAdAnim()
    {
        CoarseAdAnim.Play("New State");
    }
    
}
