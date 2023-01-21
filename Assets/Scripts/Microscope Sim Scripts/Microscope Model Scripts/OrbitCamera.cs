using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Camera Camera;
    public GameObject target;
    float speed = 5f;

    float minFov = 35f;
    float maxFov = 100f;
    float sensitivity = 17f;

    [SerializeField] private string selectableTag = "Selectable";
    
    private Vector3 origCamPos;
    private Vector3 origCamRot;

    void Awake()
    {
        origCamPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if(selection.CompareTag(selectableTag))
                {
                    var selectionGO = selection.gameObject;
                    if(selectionGO != null )
                    {
                        target = selectionGO;
                    }
                }
            }
        }


          

        if(Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);

        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = origCamPos;
            transform.rotation = Quaternion.identity;            
        }

    }
}
