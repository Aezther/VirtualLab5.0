using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Displacement : MonoBehaviour
{


    public Transform player;
    public Transform baseOrigin;
    public float totalDisplacement;

    public TMP_Text textDisp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalDisplacement = Vector3.Distance(player.position, baseOrigin.position);
        totalDisplacement = Mathf.Round(totalDisplacement * 10.0f) * 0.1f;
        string displayDisplacement = totalDisplacement.ToString("F1");
        textDisp.text = "Displacement: " + displayDisplacement + " m";
    }
}
