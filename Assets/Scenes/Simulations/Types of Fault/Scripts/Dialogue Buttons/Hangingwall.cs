using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangingwall : MonoBehaviour
{

    [SerializeField] Button Footwall;

    public void DisplayTextPanel() {
        Footwall.gameObject.SetActive(true);
    }
}
