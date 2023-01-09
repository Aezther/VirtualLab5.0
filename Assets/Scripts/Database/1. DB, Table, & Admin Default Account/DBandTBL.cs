using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class DBandTBL : MonoBehaviour
{
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Database/");
        CreateDB();
        CreateAdminAccTBL();
        CreateStudentsTBL();
        CreateTeachersTBL();
        CreateSectionsTBL();
    }

    //CREATE DATABASE named (VirtualDB)
    public void CreateDB() {
        //location where you want to place your sqlite database file.
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();//open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        Debug.Log("Database is created successfully!");
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    //CREATE ADMINS TABLE named (AdminsAccTBL)
    public void CreateAdminAccTBL() {
        //path to database, will read anything inside assets
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "CREATE TABLE IF NOT EXISTS AdminsAccTBL (AdminID INTEGER PRIMARY KEY AUTOINCREMENT, Username text NOT NULL UNIQUE, Password text NOT NULL);";
        Debug.Log("AdminAcc Table Created!");
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    //CREATE TEACHERS TABLE named (TeachersTBL)
    public void CreateTeachersTBL() {
        //path to database, will read anything inside assets
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "CREATE TABLE IF NOT EXISTS TeachersTBL (TeacherID INTEGER PRIMARY KEY, Username text NOT NULL, Password text NOT NULL" +
            ", Firstname text NOT NULL, Middlename text NOT NULL, Lastname text NOT NULL);";

        Debug.Log("Teachers Table Created!");

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    //CREATE STUDENTS TABLE named (StudentsTBL)
    public void CreateStudentsTBL() {
        //path to database, will read anything inside assets
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "CREATE TABLE IF NOT EXISTS StudentsTBL (StudentID INTEGER PRIMARY KEY, Username text NOT NULL, Password text NOT NULL" +
            ", Firstname text NOT NULL, Middlename text NOT NULL, Lastname text NOT NULL, Section text NOT NULL);";

        Debug.Log("Students Table Created!");
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    //CREATE SECTIONS TABLE named (SectionsTBL)
    public void CreateSectionsTBL() {
        //path to database, will read anything inside assets
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "CREATE TABLE IF NOT EXISTS SectionsTBL (SectionID INTEGER PRIMARY KEY AUTOINCREMENT, Sections text NOT NULL UNIQUE);";

        Debug.Log("Sections Table Created!");
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
