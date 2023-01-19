using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interact : MonoBehaviour
{
    public Button reverse;
    public Button strike;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            reverse.interactable = false;
            strike.interactable = false;
        }
    }
}
