using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncliJointAnimScript : MonoBehaviour
{
    public Animator IncliJointAnim;
    void Start()
    {
        IncliJointAnim = GetComponent<Animator>();
    }
    public void ActivateObjectivesAnim()
    {
        IncliJointAnim.Play("IncliJointAnim");
    }
    public void DisableObjectivesAnim()
    {
        IncliJointAnim.Play("New State");
    }
    
}
