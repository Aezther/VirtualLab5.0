using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPassScriptUM : MonoBehaviour
{
    public TMP_InputField PasswordIF;
    public TMP_InputField ConfirmPassIF;
    public void PasswordVisibilityShow() {
        PasswordIF.inputType = TMP_InputField.InputType.Standard;
    }
    public void PasswordVisibilityHide() {
        PasswordIF.contentType = TMP_InputField.ContentType.Password;
    }

    public void ConfirmPasswordVisibilityShow() {
        ConfirmPassIF.inputType = TMP_InputField.InputType.Standard;
    }
    public void ConfirmPasswordVisibilityHide() {
        ConfirmPassIF.contentType = TMP_InputField.ContentType.Password;
    }
}
