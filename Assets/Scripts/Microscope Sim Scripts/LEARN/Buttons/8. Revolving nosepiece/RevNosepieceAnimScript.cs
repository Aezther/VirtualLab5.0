using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevNosepieceAnimScript : MonoBehaviour
{
  public Animator RevNosepieceAnim;
    void Start()
    {
        RevNosepieceAnim = GetComponent<Animator>();
    }
    public void ActivateRevNosepieceAnim()
    {
        RevNosepieceAnim.Play("RevNosepiceAnim");
    }
    public void DisableRevNosepieceAnim()
    {
        RevNosepieceAnim.Play("New State");
    }
    
}
