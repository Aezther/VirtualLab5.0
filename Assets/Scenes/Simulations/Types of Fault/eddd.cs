using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eddd : MonoBehaviour
{
    public Button normal;
    public Button strike;
    public Button reverse;
    void Start() {

    }

    // Update is called once per frame
    public void whenButtonClicked() {
        if (Input.GetMouseButton(0) == reverse) {
            reverse.interactable = false;
            strike.interactable = false;
        }
    }
}
