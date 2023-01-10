using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;
//using static UnityEditor.ShaderData;

public class DropdownSections : MonoBehaviour
{
    public TMP_Dropdown dropdownSection;
    public string SelectedSection;
    public int index;
    void Start()
    {
        Display();





    }
    void Update() 
    {
    }
    public void Display() 
    {

        dropdownSection.ClearOptions();
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db"; //path to database, will read anything inside assets
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT Sections FROM SectionsTBL;";  
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            List<string> Sections = new List<string> { reader[0].ToString() };
            dropdownSection.AddOptions(Sections);
            //string Sections = reader.GetString(0);
            //Debug.Log(Sections);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        DropdownItemSelected(dropdownSection);
        //value change listener for dropdown which is dropdownitemselected
        dropdownSection.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdownSection); });
    }

    public void DropdownItemSelected(TMP_Dropdown dropdown) {//---------------Section;
        index = dropdown.value;
        SelectedSection = dropdown.options[index].text;
    }
}
