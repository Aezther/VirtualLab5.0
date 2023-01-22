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
    [Header("SCRIPTABLE")]
    [SerializeField] TeacherInfo teacherInfo;

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
    [Header("POP UP")]
    public GameObject SuccessfulChangepass;

    public string CurrentPass;
    void Start() {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        connectionString = "Data Source = C:\\Users\\oliva\\Documents\\VirtualLab\\VirtualLab.db";

    }

    public void btnSubmitPassword(){
        CurrentPassword();
        NewPass();
        ConfirmNewPassword();
        RegisterNewPassword();
        
    }
    public void CurrentPassword() {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                sqlQuery = "SELECT Password FROM TeachersTBL WHERE TeacherID = '"+ teacherInfo.TeacherID+ "';";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    // reinstantiate all child
                    while (reader.Read()) {
                        string CPassword = reader.GetString(0);
                        //NOT EQUAL ERROR FOR CURRENT PASSWORD
                        if (CPassword == IFCurrentPassword.text) {
                            CurrentPassError.text = "";
                        }else{
                            if (string.IsNullOrEmpty(IFCurrentPassword.text) && CPassword != IFCurrentPassword.text) {
                                CurrentPassError.text = "Your current password is empty.";
                                return;
                            }else{
                                CurrentPassError.text = "Your current password do not match.";
                            }
                        } 
                    }
                    reader.Close();
                }
                dbCmd.ExecuteNonQuery();
                //end
            }
            dbConnection.Close();
        }
    }
    public void NewPass() {
        if(IFNewPassword.text.Length >8 && !string.IsNullOrEmpty(IFNewPassword.text)){
            NewPasswordError.text = "";
        }else{
            if (!string.IsNullOrEmpty(IFNewPassword.text)&&IFNewPassword.text.Length <8){
                NewPasswordError.text = "New password must be atleast 8 characters long.";
            }else if(string.IsNullOrEmpty(IFNewPassword.text)){
                NewPasswordError.text = "Your new password field is empty.";
            }
        }
    }
    public void ConfirmNewPassword(){
        if (IFConfirmNewPassword.text == IFNewPassword.text){
            ConfirmNewPassError.text = "";
        }else{
            if (IFConfirmNewPassword.text != IFNewPassword.text){
                ConfirmNewPassError.text = "New password and confirm password do not match.";
            }else if (string.IsNullOrEmpty(IFConfirmNewPassword.text)){
                ConfirmNewPassError.text = "Your confirm password field is empty";
            }
        }
    }
    public void RegisterNewPassword(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                sqlQuery = "SELECT Password FROM TeachersTBL WHERE TeacherID = '"+ teacherInfo.TeacherID+ "';";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    // reinstantiate all child
                    while (reader.Read()) {
                        CurrentPass = reader.GetString(0);
                        //NOT EQUAL ERROR FOR CURRENT PASSWORD
                    }
                    reader.Close();
                }if ((CurrentPass == IFCurrentPassword.text) && 
                            (!string.IsNullOrEmpty(IFNewPassword.text)&&IFNewPassword.text.Length>8) && 
                            (!string.IsNullOrEmpty(IFConfirmNewPassword.text) && IFNewPassword.text == IFConfirmNewPassword.text)) {
                                //InsertNewPassinDB();
                                sqlQuery = "UPDATE TeachersTBL SET Password = '"+IFNewPassword.text+"' WHERE TeacherID = '"+teacherInfo.TeacherID+"';";
                                dbCmd.CommandText = sqlQuery;
                                dbCmd.ExecuteNonQuery();
                                SuccessfulChangepass.SetActive(true);
                                IFNewPassword.text = "";
                                IFCurrentPassword.text = "";
                                IFConfirmNewPassword.text ="";
                        }
                dbCmd.ExecuteNonQuery();
                //end
            }
            dbConnection.Close();
        }
    }
    public void CurrentPasswordVisiblityShow(){
        IFCurrentPassword.inputType = TMP_InputField.InputType.Standard;
    }
    public void CurrentPasswordVisibilityHide(){
        IFCurrentPassword.contentType = TMP_InputField.ContentType.Password;
    }
    public void NewPasswordVisibilityShow(){
        IFNewPassword.inputType = TMP_InputField.InputType.Standard;
    }
    public void NewPasswordVisibilityHide(){
        IFNewPassword.contentType = TMP_InputField.ContentType.Password;
    }
    public void ConfirmPasswordVisibilityShow(){
        IFConfirmNewPassword.inputType = TMP_InputField.InputType.Standard;
    }
    public void ConfirmPasswordVisibilityHide(){
        IFConfirmNewPassword.contentType = TMP_InputField.ContentType.Password;
    }
    
}
