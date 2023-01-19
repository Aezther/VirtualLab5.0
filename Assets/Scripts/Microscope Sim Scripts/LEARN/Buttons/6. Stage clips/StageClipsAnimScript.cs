using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClipsAnimScript : MonoBehaviour
{
   public Animator StageClipsAnim;
    void Start()
    {
        StageClipsAnim = GetComponent<Animator>();
    }
    public void ActivateStageClipsAnim()
    {
        StageClipsAnim.Play("StageClipsAnim");
    }
    public void DisableStageClipsAnim()
    {
        StageClipsAnim.Play("New State");
    }
    
}
