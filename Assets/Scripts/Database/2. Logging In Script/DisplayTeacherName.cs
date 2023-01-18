using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
using TMPro;
public class DisplayTeacherName : MonoBehaviour
{
    //public TeacherInfo teacherInfo;
    [SerializeField] TeacherInfo teacherInfo;
    public TextMeshProUGUI DisplayTeacherFullname;

    public void Awake(){

        DisplayTeacherFullname.text = teacherInfo.TeacherFullname;
    }
    


}
