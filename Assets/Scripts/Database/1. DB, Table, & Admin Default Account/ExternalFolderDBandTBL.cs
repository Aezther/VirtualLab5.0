using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
public class ExternalFolderDBandTBL : MonoBehaviour
{
    private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VirtualLab";
    private string connectionString;
    private string sqlQuery;
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        CreateFolder();
        CreateDB();
        CreateAdminAccTBL();
        CreateTeachersTBL();
        CreateSectionsTBL();
        CreateStudentsTBL();
        CreateStudentsSessionsTBL();
        CreateTeachersSessionsTBL();
        CreateScoresTBL();
        CreateSecurityQuestionsTeachersTBL();
        CreateSecurityQuestionsStudentsTBL();
    }
        public void CreateFolder(){
        Directory.CreateDirectory(folderPath);  
    }
    public void CreateDB() {
        string dbPath = folderPath + "\\VirtualLab.db";  
        if (!File.Exists(dbPath)){
            SqliteConnection.CreateFile(dbPath);
            Debug.Log("Database Created inside ");
        }
    }

     public void CreateAdminAccTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                            
                sqlQuery = "CREATE TABLE IF NOT EXISTS AdminsAccTBL (AdminID INTEGER PRIMARY KEY AUTOINCREMENT, Username text NOT NULL UNIQUE, Password text NOT NULL);";
                Debug.Log("Admin Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
        public void CreateStudentsTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                            
                sqlQuery = "CREATE TABLE IF NOT EXISTS StudentsTBL (StudentID TEXT PRIMARY KEY, Username text NOT NULL, Password text NOT NULL" +
                ", Firstname text NOT NULL, Middlename text NOT NULL, Lastname text NOT NULL, Section text NOT NULL);";
                Debug.Log("Students Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateTeachersTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                            
                sqlQuery = "CREATE TABLE IF NOT EXISTS TeachersTBL (TeacherID TEXT PRIMARY KEY, Username text NOT NULL, Password text NOT NULL" +
                ", Firstname text NOT NULL, Middlename text NOT NULL, Lastname text NOT NULL);";
                Debug.Log("Teachers Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateSectionsTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                            
                sqlQuery = "CREATE TABLE IF NOT EXISTS SectionsTBL (SectionID INTEGER PRIMARY KEY AUTOINCREMENT, Sections text NOT NULL UNIQUE);";
                Debug.Log("Sections Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateStudentsSessionsTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                            
                sqlQuery = "CREATE TABLE IF NOT EXISTS StudentSessionsTBL (SessionID INTEGER PRIMARY KEY AUTOINCREMENT, Action text, Time text, StudentID TEXT, FOREIGN KEY (StudentID) REFERENCES StudentsTBL (StudentID));";
                Debug.Log("Student Sessions Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateTeachersSessionsTBL() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {


                sqlQuery = "CREATE TABLE IF NOT EXISTS TeacherSessionsTBL (SessionID INTEGER PRIMARY KEY AUTOINCREMENT, Action text, Time text, TeacherID TEXT, FOREIGN KEY (TeacherID) REFERENCES TeachersTBL (TeacherID));";
                Debug.Log("Teacher Sessions Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateScoresTBL() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {


                sqlQuery = "CREATE TABLE IF NOT EXISTS ScoresTBL (ScoreID INTEGER PRIMARY KEY AUTOINCREMENT, Lesson text, Score INTEGER, Date text, StudentID TEXT, FOREIGN KEY (StudentID) REFERENCES StudentsTBL (StudentID));";
                Debug.Log("Scores Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void CreateSecurityQuestionsTeachersTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {


                sqlQuery = "CREATE TABLE IF NOT EXISTS SecurityQuestionsTeachersTBL (SecurityQuestionTeacherID INTEGER PRIMARY KEY AUTOINCREMENT, Question text, Answer text, TeacherID TEXT, FOREIGN KEY (TeacherID) REFERENCES TeachersTBL (TeacherID));";
                Debug.Log("Teacher Security Question Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void CreateSecurityQuestionsStudentsTBL(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {


                sqlQuery = "CREATE TABLE IF NOT EXISTS SecurityQuestionsStudentsTBL (SecurityQuestionStudentID INTEGER PRIMARY KEY AUTOINCREMENT, Question text, Answer text, StudentID TEXT, FOREIGN KEY (StudentID) REFERENCES StudentsTBL (StudentID));";
                Debug.Log("Student Security Question Table Created!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
