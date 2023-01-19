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
    [Header("User Values Student")]
    [SerializeField] GameObject filteredStudentHeaderPrefab;
    [SerializeField] GameObject ACS_content;
    [SerializeField] GameObject ACS_contentPreview;
    [SerializeField] TMP_InputField searchInputStudent;


    [Header("User Values Teacher")]

    [SerializeField] GameObject filteredTeacherHeaderPrefab;
    [SerializeField] GameObject ACT_content;
    [SerializeField] GameObject ACT_contentPreview;
    [SerializeField] TMP_InputField searchInputTeacher;


    private TextMeshProUGUI[] textCompList;

    [Header("Logs Values")]
    [SerializeField] GameObject logsHeaderPrefab;
    [SerializeField] GameObject logsContentParent;
    private TextMeshProUGUI[] logsTextCompList;

    [Header("Assessment Values")]
    [SerializeField] GameObject ARheaderPrefab;
    [SerializeField] GameObject ARcontentParent;
    [SerializeField] string selectedLesson = "Types of Faults";
    [SerializeField] Button[] lessonButtonList;
    [SerializeField] TMP_InputField ARsearchInput;


    private TextMeshProUGUI[] ARTextCompList;




    private string connectionString;
    void Start()
    {
        //connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";

        if (ACT_content && ACT_contentPreview && filteredTeacherHeaderPrefab)
        {
            DisplayStudentAccRecMain();
            DisplayStudentAccRecPreview();
        }

        if (ACS_content && ACS_contentPreview && filteredStudentHeaderPrefab)
        {
            DisplayTeacherAccRecMain();
            DisplayTeacherAccRecPreview();
            DisplayLogsToScrollView();
        }
        if (ARcontentParent && ARheaderPrefab)
        {
            DisplayARToScrollView(selectedLesson);

        }

    }

    public void DisplayStudentAccRecMain() 
    {
        // delete all child 
        foreach (Transform child in ACS_content.transform)
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
                        GameObject userHeader = GameObject.Instantiate(filteredStudentHeaderPrefab, ACS_content.transform);

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
    public void DisplayTeacherAccRecMain()
    {
        // delete all child 
        foreach (Transform child in ACT_content.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT TeacherID, Username, Firstname, Middlename, Lastname FROM TeachersTBL";
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
                        GameObject userHeader = GameObject.Instantiate(filteredTeacherHeaderPrefab, ACT_content.transform);

                        textCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        textCompList[0].text = reader.GetString(0);
                        textCompList[1].text = reader.GetString(1);
                        textCompList[2].text = reader.GetString(2);
                        textCompList[3].text = reader.GetString(3);
                        textCompList[4].text = reader.GetString(4);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayStudentAccRecPreview()
    {
        // delete all child 
        foreach (Transform child in ACS_contentPreview.transform)
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
                        GameObject userHeader = GameObject.Instantiate(filteredStudentHeaderPrefab, ACS_contentPreview.transform);

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
    public void DisplayTeacherAccRecPreview()
    {
        // delete all child 
        foreach (Transform child in ACT_contentPreview.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT TeacherID, Username, Firstname, Middlename, Lastname FROM TeachersTBL";
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
                        GameObject userHeader = GameObject.Instantiate(filteredTeacherHeaderPrefab, ACT_contentPreview.transform);

                        textCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        textCompList[0].text = reader.GetString(0);
                        textCompList[1].text = reader.GetString(1);
                        textCompList[2].text = reader.GetString(2);
                        textCompList[3].text = reader.GetString(3);
                        textCompList[4].text = reader.GetString(4);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayStudentFilteredAccRecMain()
    {
        // delete all child 
        foreach (Transform child in ACS_content.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery;
                string[] words = searchInputStudent.text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0 || searchInputStudent.text.Length == 0)
                {
                    searchInputStudent.text = "";
                    sqlQuery = "SELECT StudentID, Username, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
                }
                else
                {
                    sqlQuery = "SELECT StudentID, Username, Firstname, Middlename, Lastname, Section FROM StudentsTBL " +
                    "WHERE StudentID LIKE '' " +
                    "OR Username LIKE '" + searchInputStudent.text + "' " +
                    "OR Firstname LIKE '" + searchInputStudent.text + "' " +
                    "OR Middlename LIKE '" + searchInputStudent.text + "' " +
                    "OR Lastname LIKE '" + searchInputStudent.text + "' " +
                    "OR Section LIKE '" + searchInputStudent.text + "' ";
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
                        GameObject userHeader = GameObject.Instantiate(filteredStudentHeaderPrefab, ACS_content.transform);

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
    public void DisplayTeacherFilteredAccRecMain()
    {
        // delete all child 
        foreach (Transform child in ACT_content.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery;
                string[] words = searchInputTeacher.text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0 || searchInputTeacher.text.Length == 0)
                {
                    searchInputStudent.text = "";
                    sqlQuery = "SELECT TeacherID, Username, Firstname, Middlename, Lastname FROM TeachersTBL";
                }
                else
                {
                    sqlQuery = "SELECT TeacherID, Username, Firstname, Middlename, Lastname FROM TeachersTBL " +
                    "WHERE TeacherID LIKE '' " +
                    "OR Username LIKE '" + searchInputTeacher.text + "' " +
                    "OR Firstname LIKE '" + searchInputTeacher.text + "' " +
                    "OR Middlename LIKE '" + searchInputTeacher.text + "' " +
                    "OR Lastname LIKE '" + searchInputTeacher.text + "' ";
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
                        GameObject userHeader = GameObject.Instantiate(filteredTeacherHeaderPrefab, ACT_content.transform);

                        textCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        textCompList[0].text = reader.GetString(0);
                        textCompList[1].text = reader.GetString(1);
                        textCompList[2].text = reader.GetString(2);
                        textCompList[3].text = reader.GetString(3);
                        textCompList[4].text = reader.GetString(4);
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

                       // Debug.Log(logsTextCompList[0].gameObject.name);
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
    public void DisplayARToScrollView( string lesson)
    {
        selectedLesson = lesson;
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
                string sqlQuery = "SELECT Username, Lastname, Firstname, Section, Score, Date FROM ScoresTBL INNER JOIN StudentsTBL ON StudentsTBL.StudentID = ScoresTBL.StudentID WHERE ScoresTBL.Lesson = '" + lesson + "';";

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

                        Debug.Log(ARTextCompList[0].gameObject.name);
                        ARTextCompList[0].text = reader.GetString(0);
                        ARTextCompList[1].text = reader.GetString(1);
                        ARTextCompList[2].text = reader.GetString(2);
                        ARTextCompList[3].text = reader.GetString(3);
                        ARTextCompList[4].text = reader.GetInt32(4).ToString();
                        ARTextCompList[5].text = reader.GetString(5);

                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void DisplayFilteredARToScrollView()
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
                string sqlQuery;
                string[] words = ARsearchInput.text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0 || ARsearchInput.text.Length == 0)
                {
                    sqlQuery = "SELECT Username, Lastname, Firstname, Section, Score, Date FROM ScoresTBL INNER JOIN StudentsTBL ON StudentsTBL.StudentID = ScoresTBL.StudentID WHERE ScoresTBL.Lesson = '" + selectedLesson + "';";

                }
                else
                {
                    sqlQuery = "SELECT Username, Lastname, Firstname, Section, Score, Date FROM ScoresTBL INNER JOIN StudentsTBL ON StudentsTBL.StudentID = ScoresTBL.StudentID WHERE ScoresTBL.Lesson = '" + selectedLesson + "' AND( StudentsTBL.Username LIKE '" + ARsearchInput.text + "' OR StudentsTBL.Lastname like '" + ARsearchInput.text + "' OR StudentsTBL.Firstname LIKE '" + ARsearchInput.text + "' OR StudentsTBL.Section LIKE '" + ARsearchInput.text + "' OR ScoresTBL.Score LIKE '" + ARsearchInput.text + "' OR ScoresTBL.Date LIKE '" + ARsearchInput.text + "' );";
                }

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

                        Debug.Log(ARTextCompList[0].gameObject.name);
                        ARTextCompList[0].text = reader.GetString(0);
                        ARTextCompList[1].text = reader.GetString(1);
                        ARTextCompList[2].text = reader.GetString(2);
                        ARTextCompList[3].text = reader.GetString(3);
                        ARTextCompList[4].text = reader.GetInt32(4).ToString();
                        ARTextCompList[5].text = reader.GetString(5);

                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    public void RefreshAR()
    {
        for (int i = 0; i < lessonButtonList.Length; i++)
        {
            if (lessonButtonList[i].IsInteractable() == false)
            {
                DisplayARToScrollView( selectedLesson);
            }
        }
    }
    public void UpdateAccRecDisplay()
    {
        DisplayStudentAccRecMain();
        DisplayStudentAccRecPreview();

        DisplayTeacherAccRecMain();
        DisplayTeacherAccRecPreview();
    }
}
