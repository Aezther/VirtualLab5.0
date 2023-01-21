using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAnimScript : MonoBehaviour
{
   public Animator StageAnim;
    void Start()
    {
        StageAnim = GetComponent<Animator>();
    }
    public void ActivateStageAnim()
    {
        StageAnim.Play("StageAnim");
    }
    public void DisableStageAnim()
    {
        StageAnim.Play("New State");
    }
    
}
