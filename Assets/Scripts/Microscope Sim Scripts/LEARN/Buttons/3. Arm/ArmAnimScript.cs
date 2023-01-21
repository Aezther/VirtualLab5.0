using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimScript : MonoBehaviour
{
   public Animator ArmAnim;
    void Start()
    {
        ArmAnim = GetComponent<Animator>();
    }
    public void ActivateArmAnim()
    {
        ArmAnim.Play("ArmAnim");
    }
    public void DisableArmAnim()
    {
        ArmAnim.Play("New State");
    }
    
}