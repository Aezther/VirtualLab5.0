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

public class SecurityQuestion : MonoBehaviour
{
    [Header("SCRIPTABLE")]
    [SerializeField] TeacherInfo teacherInfo;

    [Header("SECURITY QUESTION INPUTFIELD")]
    public TMP_InputField IFSecurityQuestion;
    public TMP_InputField IFAnswer;
    [Header("ERROR SECURITY ANSWER")]
    public TextMeshProUGUI SQError;
    public TextMeshProUGUI AnswerError;
    [Header("SQLITE")]
    private string connectionString;
    private string sqlQuery;
    [Header("POP UP")]
    public GameObject SuccessQuestionAnswerNotif;

    // Start is called before the first frame update
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
    }
    public void ValidateSubmit(){
        AddSecurityQuestion();
        AddSecurityAnswer();
        RegisterQuestionAnswerDB();
    }
    public void AddSecurityQuestion(){
        
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //start
                if (string.IsNullOrEmpty(IFSecurityQuestion.text)){
                    SQError.text = "Security Question is empty.";
                    return;
                }else{
                    SQError.text = "";
                }
                if (string.IsNullOrWhiteSpace(IFSecurityQuestion.text.Trim())){
                    SQError.text = "Security Question contains spaces.";
                    return;
                }else {
                    SQError.text = "";
                }
            }
            dbConnection.Close();
        }
    }

    public void AddSecurityAnswer(){
        if (string.IsNullOrEmpty(IFAnswer.text)){
            AnswerError.text = "Answer field is empty.";
            return;
        }else{
            AnswerError.text = "";
        }
        if (string.IsNullOrWhiteSpace(IFAnswer.text.Trim())){
            AnswerError.text = "Answer field contains spaces.";
            return;
        }else{
            AnswerError.text = "";
        }
    }
    public void RegisterQuestionAnswerDB() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                if( (!string.IsNullOrEmpty(IFSecurityQuestion.text)&& !string.IsNullOrWhiteSpace(IFSecurityQuestion.text.Trim())) && 
                    (!string.IsNullOrEmpty(IFAnswer.text) && !string.IsNullOrWhiteSpace(IFSecurityQuestion.text.Trim()))     ){
                    sqlQuery = "INSERT INTO SecurityQuestionsTeachersTBL (Question, Answer, TeacherID) VALUES ('"+IFSecurityQuestion.text+"', '"+IFAnswer.text+"', '"+teacherInfo.TeacherID+"')";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    IFSecurityQuestion.text = "";
                    IFAnswer.text = "";
                    Debug.Log("Security Question and Answer is added");
                    SuccessQuestionAnswerNotif.SetActive(true);
                } 
            }
            dbConnection.Close();
        }
    }
}
