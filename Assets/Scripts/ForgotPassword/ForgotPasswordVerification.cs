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
public class ForgotPasswordVerification : MonoBehaviour
{
    [Header("INPUTFIELDS")]
    public TMP_InputField TeacherID;
    public TMP_InputField SecurityQuestionAnswer;
    public TMP_InputField SetNewPassword;
    public TMP_InputField SetConfirmNewPassword;

    [Header("TEXTS")]
    public TextMeshProUGUI SecurityQuestionDisplayText;
    [Header("POP UPS")]
    public GameObject SuccessNotification;
    [Header("ERRORS")]
    public TextMeshProUGUI TeacherIDError;
    public TextMeshProUGUI SecurityQuestionAnswerError;
    public TextMeshProUGUI NewPasswordError;
    public TextMeshProUGUI ConfirmPasswordError;
    [Header("SQL")]
    private string connectionString;
    private string sqlQuery;
    private string listofTeacherID;
    [Header ("PANELS")]
    public GameObject AskSecurityQuestion;
    public GameObject AskNewPassword;
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";

    }
    public void first(){
        ValidateID();
        //GetTeacherID();
    }
    //CHECK IF USER ID HAS A SECURITY QUESTION
    public void ValidateID (){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                sqlQuery = "SELECT TeacherID FROM SecurityQuestionsTeachersTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.Log(reader.GetString(0));
                        string listofTeacherIDwithSQuestions = reader.GetString(0);
                        

                        if (listofTeacherIDwithSQuestions == TeacherID.text){
                            TeacherIDError.text = "Success!.";
                            AskSecurityQuestion.SetActive(true);
                            GetTeacherID();
                            //TeacherID.text = ""; //should not clear input field
                            TeacherIDError.text = ""; // clear error message
                            
                            return;
                        }else{
                            if(string.IsNullOrEmpty(TeacherID.text)){
                                TeacherIDError.text = "TeacherID Inputfield is empty.";
                            }
                            else if(listofTeacherIDwithSQuestions != TeacherID.text){
                                TeacherIDError.text = "Invalid ID or Security question was not established.";
                            }
                        } 
                    }
                    reader.Close();
                //end
                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    //GET TEACHER ID AND SET THE QUESTION IN THE PANEL
    public void GetTeacherID(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                sqlQuery = "SELECT Question FROM SecurityQuestionsTeachersTBL WHERE TeacherID = '"+TeacherID.text+"';";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    // reinstantiate all child
                    while (reader.Read()) {
                        string Question = reader.GetString(0);
                        Debug.Log(Question);
                        SecurityQuestionDisplayText.text = Question;
                    }
                    reader.Close();
                }
                dbCmd.ExecuteNonQuery();
                //end
            }
            dbConnection.Close();
        }
    }
    //CHECK ANSWER IF CORRECT, IT WILL PROCEED TO QUESTION
    public void CheckAnswer(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                sqlQuery = "SELECT Question, Answer FROM SecurityQuestionsTeachersTBL WHERE TeacherID = '"+TeacherID.text+"';";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        string Question = reader.GetString(0);
                        string Answer = reader.GetString(1);
                        
                        Debug.Log(Answer + Question);
                        if (SecurityQuestionAnswer.text == Answer){
                            Debug.Log("Success");
                            AskNewPassword.SetActive(true);
                            return;
                        }else{
                            if (string.IsNullOrEmpty(SecurityQuestionAnswer.text)){
                                SecurityQuestionAnswerError.text = "Answer inputfield is empty.";

                            }else if(Answer!=SecurityQuestionAnswer.text){
                                SecurityQuestionAnswerError.text = "Invalid Answer";

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
    //UPDATE PASSWORD CALL
    public void UpdatePassword(){
        VerifyNewPassword ();
        VerifyConfirmPassword();
        VerifyNewAndConfirmPassword();
    }
    //VERIFY NEW PASSWORD
    public void VerifyNewPassword(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                
                if(string.IsNullOrEmpty(SetNewPassword.text)){
                    NewPasswordError.text = "New password is empty.";
                    return;
                }else{
                    NewPasswordError.text = "";
                }
                if(string.IsNullOrWhiteSpace(SetNewPassword.text)){
                    NewPasswordError.text = "New password field contains spaces.";
                }else{
                    NewPasswordError.text = "";
                }
                if(SetNewPassword.text.Length < 8){
                    NewPasswordError.text = "New password must be atleast 8 characters";
                    return;
                }else{
                    NewPasswordError.text = "";
                }

                sqlQuery = "UPDATE TeachersTBL SET Password = '"+SetNewPassword.text+"' WHERE TeacherID = '"+TeacherID.text+"';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
                //end
            }

            dbConnection.Close();
        }
    }
        //VERIFY CONFIRM PASSWORD
    public void VerifyConfirmPassword(){
                
                if(string.IsNullOrEmpty(SetConfirmNewPassword.text)){
                    ConfirmPasswordError.text = "New password is empty.";
                    return;
                }else{
                    ConfirmPasswordError.text = "";
                }
                if(string.IsNullOrWhiteSpace(SetConfirmNewPassword.text)){
                    ConfirmPasswordError.text = "Confirm password field contains spaces.";
                    return;
                }else{
                    ConfirmPasswordError.text = "";
                }
                if(SetNewPassword.text != SetConfirmNewPassword.text){
                    ConfirmPasswordError.text ="Your passwords do not match";
                    return;
                }else{
                    ConfirmPasswordError.text = "";
                }
                
                

                //sqlQuery = "UPDATE TeachersTBL SET Password = '"+SetNewPassword.text+"' WHERE TeacherID = '"+TeacherID.text+"';";
                //dbCmd.CommandText = sqlQuery;
                //dbCmd.ExecuteNonQuery();
                //end
    }
    public void VerifyNewAndConfirmPassword(){
         using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                if (    (!string.IsNullOrEmpty(SetNewPassword.text) && !string.IsNullOrWhiteSpace(SetNewPassword.text)) && (SetNewPassword.text.Length > 8) &&
                        (!string.IsNullOrEmpty(SetConfirmNewPassword.text) && !string.IsNullOrWhiteSpace(SetConfirmNewPassword.text) && (SetNewPassword.text == SetConfirmNewPassword.text))){
                        sqlQuery = "UPDATE TeachersTBL SET Password = '"+SetNewPassword.text+"' WHERE TeacherID = '"+TeacherID.text+"';";
                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteNonQuery();
                        SuccessNotification.SetActive(true);
                }


                //end
            }

            dbConnection.Close();
        }
    }
    
    public void NewPasswordVisibilityShow(){
        SetNewPassword.inputType = TMP_InputField.InputType.Standard;
    }
    public void NewPasswordVisibilityHide(){
        SetNewPassword.contentType = TMP_InputField.ContentType.Password;
    }
    public void ConfirmPasswordVisibilityShow(){
        SetConfirmNewPassword.inputType = TMP_InputField.InputType.Standard;
    }
    public void ConfirmPasswordVisibilityHide(){
        SetConfirmNewPassword.contentType = TMP_InputField.ContentType.Password;
    }
}