using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassScript : MonoBehaviour
{
    public TMP_InputField PasswordIF;

    public void PasswordVisibilityShow() {
        PasswordIF.inputType = TMP_InputField.InputType.Standard;
    }
    public void PasswordVisibilityHide() {
        PasswordIF.contentType = TMP_InputField.ContentType.Password;

    }
}
