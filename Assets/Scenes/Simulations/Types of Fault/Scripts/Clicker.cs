using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Clicker : MonoBehaviour
{
    public Button reverse;
    public Button normal;
    public Button slip;

    // Start is called before the first frame update
    void Update() {
        if (Input.GetMouseButton(0) == true) {
            normal.interactable = false;
            slip.interactable = false;
        }
    }

}
