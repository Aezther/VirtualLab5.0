using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesAnimScript : MonoBehaviour
{
    public Animator ObjectivesAnim;
    void Start()
    {
        ObjectivesAnim = GetComponent<Animator>();
    }
    public void ActivateObjectivesAnim()
    {
        ObjectivesAnim.Play("ObjectivesAnim");
    }
    public void DisableObjectivesAnim()
    {
        ObjectivesAnim.Play("New State");
    }
    
}
