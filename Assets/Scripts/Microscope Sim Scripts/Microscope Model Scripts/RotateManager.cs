using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{

    public GameObject microModel;
    public Quaternion origRotVal;
    float rotationResetSpeed = 1.0f;
    [SerializeField] Camera eyePiece;
    [SerializeField] Camera bodyTube;
    [SerializeField] Camera armCam;
    [SerializeField] Camera baseCam;
    [SerializeField] Camera stageCam;
    [SerializeField] Camera stageClips;
    [SerializeField] Camera mirrorCam;
    [SerializeField] Camera revNP;
    [SerializeField] Camera fadjKnob;
    [SerializeField] Camera cadjKnob;
    [SerializeField] Camera objCam;
    [SerializeField] Camera incJoint;
    [SerializeField] Camera diaCam;
    // Start is called before the first frame update
    void Start()
    {
        microModel.GetComponent<GrabRotate>().rotationSpeed = 0;
        origRotVal = microModel.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
                if(Input.GetKeyDown(KeyCode.Space))
        {
            microModel.transform.rotation = Quaternion.Slerp(microModel.transform.rotation, origRotVal, Time.time * rotationResetSpeed);
        }
        
    }

    public void rotateEnabled()
    {  
        microModel.GetComponent<GrabRotate>().rotationSpeed = 10;

    }

    public void resetRotation()
    {
         microModel.transform.rotation = Quaternion.Slerp(microModel.transform.rotation, origRotVal, Time.time * rotationResetSpeed);
    }

    public void disableRot()
    {
        microModel.GetComponent<GrabRotate>().rotationSpeed = 0;
    }

    public void defaultCamera()
    {
        eyePiece.gameObject.SetActive(false);
        bodyTube.gameObject.SetActive(false);
        armCam.gameObject.SetActive(false);
        baseCam.gameObject.SetActive(false);
        stageCam.gameObject.SetActive(false);
        stageClips.gameObject.SetActive(false);
        mirrorCam.gameObject.SetActive(false);
        revNP.gameObject.SetActive(false);
        fadjKnob.gameObject.SetActive(false);
        cadjKnob.gameObject.SetActive(false);
        objCam.gameObject.SetActive(false);
        incJoint.gameObject.SetActive(false);
        diaCam.gameObject.SetActive(false);

    }
}
