using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Xml.Linq;
public class DisplayUserValues : MonoBehaviour
{
    [Header("TEXTS")]
    public TextMeshProUGUI UserID;
    public TextMeshProUGUI UserName;
    public TextMeshProUGUI FirstName;
    public TextMeshProUGUI MiddleName;
    public TextMeshProUGUI LastName;
    public TextMeshProUGUI Section;

    private string connectionString;
    void Start()
    {
        connectionString = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        DisplayToScrollView();
    }

    public void DisplayToScrollView() {

        UserID.text = "";
        UserName.text = "";
        FirstName.text = "";
        MiddleName.text = "";
        LastName.text = "";
        Section.text = "";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                string sqlQuery = "SELECT * FROM TeachersTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {

                        UserID.text += reader.GetInt32(0).ToString() + "\n";
                        UserName.text += reader.GetString(1) + "\n";
                        FirstName.text += reader.GetString(3) + "\n";
                        MiddleName.text += reader.GetString(4) + "\n";
                        LastName.text += reader.GetString(5) + "\n";
                        Section.text += "Teacher" + "\n";


                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
