using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VelocityDirection : MonoBehaviour
{
    public TMP_Text balloneDir;
    public TMP_Text balltwoDir;
    public TMP_Text ballthreeDir;

    // Start is called before the first frame update
    void Start()
    {
        
        string[] directions = { "North", "East", "South", "West" };
        int dircount = Random.Range(0, 4);
        balloneDir.text = (directions[dircount]);
        balltwoDir.text = (directions[dircount]);
        ballthreeDir.text = (directions[dircount]);
        Debug.Log(directions[dircount]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
