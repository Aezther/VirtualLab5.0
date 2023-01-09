using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_InputField Surname;
    public TMP_InputField LRN;
    public void transferText() {
        Surname.text = LRN.text;
        Debug.Log(Surname.text + "." + LRN.text);
    }
}
