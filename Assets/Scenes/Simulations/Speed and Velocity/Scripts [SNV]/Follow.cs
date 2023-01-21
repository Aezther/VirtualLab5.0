using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] public Transform lookAt; // asks for what object it's supposed to follow
    [SerializeField] public Vector3 offset; // offsets the text x,y,z axis

    private Camera cam;

    void Start()  // Start is called before the first frame update
    {
        cam = Camera.main; // sets the cam = the main camera
    }

    void Update() // Update is called once per frame
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset); 

        if (transform.position != pos)
        {
            transform.position = pos;
        }
    }
}