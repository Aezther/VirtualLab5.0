using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class TeacherArchiveData : ScriptableObject
{
    [Header("Accessible strings")]

    public string id;
    public string username;
    public string password;
    public string firstname;
    public string middlename;
    public string lastname;

}
