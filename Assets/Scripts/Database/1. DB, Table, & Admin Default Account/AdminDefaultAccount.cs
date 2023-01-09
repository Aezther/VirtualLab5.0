using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class AdminDefaultAccount : MonoBehaviour
{

    void Start()
    {
        CreateAdminAccounts("Admin1", "1234");
        CreateAdminAccounts();
    }

    public void CreateAdminAccounts(string User, string Pass) {
        // string conn = "URI=file:" + Application.dataPath + "/Database/"+"/testdb.db";
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db"; //path to database, will read anything inside assets
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "INSERT INTO AdminsAccTBL (Username, Password) VALUES('" + User + "','" + Pass + "');";


        Debug.Log("Admin1 added Successfully!");
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    public void CreateAdminAccounts() {
        // string conn = "URI=file:" + Application.dataPath + "/Database/"+"/testdb.db";
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db"; //path to database, will read anything inside assets
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "INSERT INTO AdminsAccTBL (Username, Password) VALUES('Admin2','qwerty');";
        Debug.Log("Admin2 added Successfully!");
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
