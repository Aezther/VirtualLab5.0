using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;
using Ookii.Dialogs;

public class ChangePassSecurityQuestion : MonoBehaviour
{
    [Header("CHANGE PASSWORD INPUTFIELDS")]
    public TMP_InputField IFCurrentPassword;
    public TMP_InputField IFNewPassword;
    public TMP_InputField IFConfirmNewPassword;

    [Header("Error Handling")]
    public TextMeshProUGUI CurrentPassError;
    public TextMeshProUGUI NewPasswordError;
    public TextMeshProUGUI ConfirmNewPassError;
    [Header("SQLITE")]
    private string connectionString;
    private string sqlQuery;
    void Start() {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
    }

    public void ValidateNewPassword() {

    }
    public void CurrentPassword() {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                sqlQuery = "SELECT Password FROM TeachersTBL WHERE TeacherID = ";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    // reinstantiate all child
                    while (reader.Read()) {
                        
                    }
                    reader.Close();
                }
                dbCmd.ExecuteNonQuery();
                //end
            }
            dbConnection.Close();
        }
    }
}
