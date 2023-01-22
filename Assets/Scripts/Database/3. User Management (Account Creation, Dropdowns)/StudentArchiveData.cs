using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StudentArchiveData : ScriptableObject
{
    [Header ("TMP")]
    [SerializeField] TextMeshProUGUI idTM;
    [SerializeField] TextMeshProUGUI usernameTM;
    [SerializeField] TextMeshProUGUI passwordTM;

    [SerializeField] TextMeshProUGUI firstnameTM;
    [SerializeField] TextMeshProUGUI middlenameTM;
    [SerializeField] TextMeshProUGUI lastnameTM;
    [SerializeField] TextMeshProUGUI sectionTM;

    [Header("Accessible strings")]

    public string id;
    public string username;
    public string password;
    public string firstname;
    public string middlename;
    public string lastname;
    public string section;


    public void UpdateValues()
    {
        id = idTM.text;
        username = usernameTM.text;
        password = passwordTM.text;
        firstname = firstnameTM.text;
        middlename= middlenameTM.text;
        lastname= lastnameTM.text;
        section = sectionTM.text;
    }
}