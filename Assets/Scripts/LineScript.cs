using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    public LineRenderer line;
    public Transform player;
    public Transform baseorigin;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, player.position);
        line.SetPosition(1, baseorigin.position);

    }
}
