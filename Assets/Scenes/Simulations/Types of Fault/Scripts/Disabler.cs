using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disabler : MonoBehaviour
{
    public Button normal;
    void Start() {

    }

    // Update is called once per frame
    public void whenButtonClicked() {
        if (Input.GetMouseButton(0) == true) {
            normal.interactable = false;
        }
    }
}
