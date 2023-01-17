using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Xml.Linq;
public class DisplayDBValues : MonoBehaviour
{
    [Header("User Values")]
    [SerializeField] GameObject filteredHeaderPrefab;
    [SerializeField] GameObject contentParent;
    [SerializeField] TMP_InputField searchInput;
    private TextMeshProUGUI[] textCompList;

    [Header("Logs Values")]
    [SerializeField] GameObject logsHeaderPrefab;
    [SerializeField] GameObject logsContentParent;
    private TextMeshProUGUI[] logsTextCompList;

    [Header("Assessment Values")]
    [SerializeField] GameObject ARheaderPrefab;
    [SerializeField] GameObject ARcontentParent;
    private TextMeshProUGUI[] ARTextCompList;




    private string connectionString;
    void Start()
    {
        //connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        connectionString = "Data Source = C:\\Users\\oliva\\Documents\\VirtualLab\\VirtualLab.db";

        DisplayUsersToScrollView();
        DisplayLogsToScrollView();

    }

    public void DisplayUsersToScrollView() 
    {
        // delete all child 
        foreach (Transform child in contentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) 
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) 
            {
                string sqlQuery = "SELECT StudentID, Username, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) 
                {
                    // reinstantiate all child
                    while (reader.Read()) 
                    {
                        // one loop = 1 user
                        //Debug.Log(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5));
                        // create prefab
                        // modify value
                        GameObject userHeader = GameObject.Instantiate(filteredHeaderPrefab, contentParent.transform);

                        textCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                            //Debug.Log(textCompList[0].gameObject.name);
                            textCompList[0].text = reader.GetString(0);
                            textCompList[1].text = reader.GetString(1);
                            textCompList[2].text = reader.GetString(2);
                            textCompList[3].text = reader.GetString(3);
                            textCompList[4].text = reader.GetString(4);
                            textCompList[5].text = reader.GetString(5);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayFilteredUsersToScrollView()
    {
        // delete all child 
        foreach (Transform child in contentParent.transform)
        {
            Destroy(child.gameObject);
        }

  

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery;
                string[] words = searchInput.text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0 || searchInput.text.Length == 0)
                {
                    searchInput.text = "";
                     sqlQuery = "SELECT StudentID, Username, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
                }
                else
                {
                    sqlQuery = "SELECT StudentID, Username, Firstname, Middlename, Lastname, Section FROM StudentsTBL " +
                    "WHERE StudentID LIKE '' " +
                    "OR Username LIKE '" + searchInput.text + "' " +
                    "OR Firstname LIKE '" + searchInput.text + "' " +
                    "OR Middlename LIKE '" + searchInput.text + "' " +
                    "OR Lastname LIKE '" + searchInput.text + "' " +
                    "OR Section LIKE '" + searchInput.text + "' ";
                }
                 
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    // reinstantiate all child
                    while (reader.Read())
                    {
                        // one loop = 1 user
                        //Debug.Log(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5));
                        // create prefab
                        // modify value
                        GameObject userHeader = GameObject.Instantiate(filteredHeaderPrefab, contentParent.transform);

                        textCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        textCompList[0].text = reader.GetString(0);
                        textCompList[1].text = reader.GetString(1);
                        textCompList[2].text = reader.GetString(2);
                        textCompList[3].text = reader.GetString(3);
                        textCompList[4].text = reader.GetString(4);
                        textCompList[5].text = reader.GetString(5);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayLogsToScrollView()
    {
        // delete all child 
        foreach (Transform child in logsContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT Username, Firstname, Lastname, Action, Time FROM StudentSessionsTBL  INNER JOIN StudentsTBL ON StudentsTBL.StudentID = StudentSessionsTBL.StudentID";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    // reinstantiate all child
                    while (reader.Read())
                    {
                        // one loop = 1 user
                        //Debug.Log(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4));
                        // create prefab
                        // modify value
                        GameObject userHeader = GameObject.Instantiate(logsHeaderPrefab, logsContentParent.transform);

                        logsTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        Debug.Log(textCompList[0].gameObject.name);
                        logsTextCompList[0].text = reader.GetString(0);
                        logsTextCompList[1].text = reader.GetString(1);
                        logsTextCompList[2].text = reader.GetString(2);
                        logsTextCompList[3].text = reader.GetString(3);
                        logsTextCompList[4].text = reader.GetString(4);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayARToScrollView()
    {
        // delete all child 
        foreach (Transform child in ARcontentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT Lastname, Firstname, Section, Subject, Score FROM ScoresTBL  INNER JOIN StudentsTBL ON StudentsTBL.StudentID = ScoresTBL.StudentID";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    // reinstantiate all child
                    while (reader.Read())
                    {
                        // one loop = 1 user
                        //Debug.Log(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4));
                        // create prefab
                        // modify value
                        GameObject userHeader = GameObject.Instantiate(ARheaderPrefab, ARcontentParent.transform);

                        ARTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        Debug.Log(textCompList[0].gameObject.name);
                        ARTextCompList[0].text = reader.GetString(0);
                        ARTextCompList[1].text = reader.GetString(1);
                        ARTextCompList[2].text = reader.GetString(2);
                        ARTextCompList[3].text = reader.GetString(3);
                        ARTextCompList[4].text = reader.GetInt32(4).ToString();
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
