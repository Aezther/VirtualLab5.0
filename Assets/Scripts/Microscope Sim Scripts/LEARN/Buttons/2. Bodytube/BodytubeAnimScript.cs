using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodytubeAnimScript : MonoBehaviour
{
    public Animator BodytubeAnim;
    void Start()
    {
        BodytubeAnim = GetComponent<Animator>();
    }
    public void ActivateBodytubeAnim()
    {
        BodytubeAnim.Play("BodytubeAnim");
    }
    public void DisableBodytubeAnim()
    {
        BodytubeAnim.Play("New State");
    }
    
}
