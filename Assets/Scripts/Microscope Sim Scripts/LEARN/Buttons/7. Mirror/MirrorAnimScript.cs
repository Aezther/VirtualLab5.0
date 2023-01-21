using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorAnimScript : MonoBehaviour
{
  public Animator MirrorAnim;
    void Start()
    {
        MirrorAnim = GetComponent<Animator>();
    }
    public void ActivateMirrorAnim()
    {
        MirrorAnim.Play("MirrorAnim");
    }
    public void DisableMirrorAnim()
    {
        MirrorAnim.Play("New State");
    }
    
}
