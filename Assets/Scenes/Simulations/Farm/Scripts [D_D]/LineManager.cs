using UnityEngine;

public class LineManager : MonoBehaviour
{

    public LineRenderer line;
    public Transform Anchor;
    public Transform Object;


    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 62;
        line.positionCount = 2;
       
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, Anchor.position);
        line.SetPosition(1, Object.position);
    }
}
