using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLFScriptForMovement : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AnimMove() {
        Anim.Play("SSLMovement");
    }
}
