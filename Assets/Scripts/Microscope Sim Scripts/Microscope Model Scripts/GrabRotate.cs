using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void OnMouseDrag(){

        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, XaxisRotation, Space.World);
	    // transform.Rotate(Vector3.right, YaxisRotation, Space.World); 
        
    }

}
