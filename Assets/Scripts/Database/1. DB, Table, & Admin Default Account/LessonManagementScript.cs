using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;
public class LessonManagementScript : MonoBehaviour
{

    private string connectionString;
    private string sqlQuery;
    
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        RegisterLessonStatus();
    }
    
    public void RegisterLessonStatus(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                try {
                    sqlQuery = "INSERT INTO LessonsTBL (LessonName, LessonStatus) VALUES('ToF','Enabled');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("ToF is created!");
                    
                    sqlQuery = "INSERT INTO LessonsTBL (LessonName, LessonStatus) VALUES('DnD','Enabled');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("DnD is created!");

                    sqlQuery = "INSERT INTO LessonsTBL (LessonName, LessonStatus) VALUES('Microscope','Enabled');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("Microscope is created!");
                    

                    sqlQuery = "INSERT INTO LessonsTBL (LessonName, LessonStatus) VALUES('SnV','Enabled');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("SnV is created!");
                    
                }catch(SqliteException ex){
                    Debug.Log("An error occured: " + ex.Message);
                }
            }
            dbConnection.Close();
        }
    }

}
