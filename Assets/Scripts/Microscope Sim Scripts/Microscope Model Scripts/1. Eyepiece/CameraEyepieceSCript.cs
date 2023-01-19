using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEyepieceSCript : MonoBehaviour
{
    public Animator CameraEyepieceAnim;
    void Start()
    {
        CameraEyepieceAnim = GetComponent<Animator>();
    }



    public void ActivateAnimEyepiece()
    {
        CameraEyepieceAnim.Play("EyepieceAnimCameraMovement");
    }

    public void ActivateBodyTube()
    {
        CameraEyepieceAnim.Play("Bodytube");
    }

    public void MovetoEyePiece(){
        CameraEyepieceAnim.Play("");
    }
}
