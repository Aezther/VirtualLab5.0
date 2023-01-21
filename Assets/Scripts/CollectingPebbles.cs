using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectingPebbles : MonoBehaviour
{

    public int pebbles;
    public GameObject dLight;
    public GameObject pLight;
    public GameObject bLight;

    public TMP_Text objCount;

    public TMP_Text questObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Pebble")
        {
            Debug.Log("Pebble collected!");
            Col.gameObject.SetActive(false);
            pebbles++;
            objCount.text = "- Noir Cylinder found: " + pebbles + "/5";
        }

        if(pebbles>=5
        ){
            Debug.Log("Power has been restored!");
            dLight.SetActive(true);
            pLight.SetActive(false);
            bLight.SetActive(false);
            objCount.text = "Power restored!";
            questObj.text = "• Find 5 Noir Cylinder batteries to restore the power. [COMPLETE]";
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
