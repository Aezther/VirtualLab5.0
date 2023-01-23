using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class ActivateDeactivateLesson : MonoBehaviour
{
    private string connectionString;
    private string sqlQuery;

    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
    }
    

    public void setTOFDisabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Disabled' WHERE LessonName = 'ToF';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Types of Fault is Disabled");
            }
            dbConnection.Close();
        }
    }
     public void setTOFEnabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Enabled' WHERE LessonName = 'ToF';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Types of Fault is Enabled");
            }
            dbConnection.Close();
        }
    }

    public void setDnDDisabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Disabled' WHERE LessonName = 'DnD';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Distance and Displacement is Disabled");
            }
            dbConnection.Close();
        }
    }
     public void setDnDEnabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Enabled' WHERE LessonName = 'DnD';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Distance and Displacement is Enabled");
            }
            dbConnection.Close();
        }
    }

    public void setMicroscopeDisabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Disabled' WHERE LessonName = 'Microscope';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Microscope is Disabled");
            }
            dbConnection.Close();
        }
    }
     public void setMicroscopeEnabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Enabled' WHERE LessonName = 'Microscope';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Microscope is Enabled");
            }
            dbConnection.Close();
        }
    }

    public void setSnVDisabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Disabled' WHERE LessonName = 'SnV';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Speed and Velocity is Disabled");
            }
            dbConnection.Close();
        }
    }
     public void setSnVEnabled(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                sqlQuery = "UPDATE LessonsTBL SET LessonStatus = 'Enabled' WHERE LessonName = 'SnV';";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                Debug.Log("Speed and Velocity is Enabled");
            }
            dbConnection.Close();
        }
    }
}
