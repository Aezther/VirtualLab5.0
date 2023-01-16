using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
public class AdminDefAccount : MonoBehaviour
{
    private string connectionString;
    private string sqlQuery;
    
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        RegisterAcc();
    }

    public void RegisterAcc() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                try {
                    sqlQuery = "INSERT INTO AdminsAccTBL (Username, Password) VALUES('Admin1','1234');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("Admin2 Account is created!");
                    
                    sqlQuery = "INSERT INTO AdminsAccTBL (Username, Password) VALUES('Admin2','qwerty');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("Admin2 Account is created!");
                    
                }catch(SqliteException ex){
                    Debug.Log("An error occured: " + ex.Message);
                }
            }
            dbConnection.Close();
        }
    }
}
