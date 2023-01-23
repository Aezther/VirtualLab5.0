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
    private TextMeshProUGUI[] studTextCompList;


    [Header("User Values Teacher")]

    [SerializeField] GameObject filteredTeacherHeaderPrefab;
    [SerializeField] GameObject ACT_content;
    [SerializeField] GameObject ACT_contentPreview;
    [SerializeField] TMP_InputField searchInputTeacher;
    private TextMeshProUGUI[] teachTextCompList;

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

    [Header("Sections Archive Values")]
    [SerializeField] GameObject sArchHeaderPrefab;
    [SerializeField] GameObject sArchContentParent;
    private TextMeshProUGUI[] sArchTextCompList;

    [Header("Student Archive Values")]
    [SerializeField] GameObject stArchHeaderPrefab;
    [SerializeField] GameObject stArchRestoreHeaderPrefab;

    [SerializeField] GameObject stArchContentParent;
    private TextMeshProUGUI[] stArchTextCompList;
    private TextMeshProUGUI[] stArchResTextCompList;

    [Header("Teacher Archive Values")]
    [SerializeField] GameObject tArchHeaderPrefab;
    [SerializeField] GameObject tArchRestoreHeaderPrefab;

    [SerializeField] GameObject tArchContentParent;
    private TextMeshProUGUI[] tArchTextCompList;
    private TextMeshProUGUI[] tArchResTextCompList;







    private string connectionString;
    void Start()
    {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        //connectionString = "Data Source = C:\\Users\\oliva\\Documents\\VirtualLab\\VirtualLab.db";

        if (ACT_content && ACT_contentPreview && filteredTeacherHeaderPrefab)
        {
            UpdateStudentAccRec();
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
                string sqlQuery = "SELECT StudentID, Username, Password, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
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
                        userHeader.SetActive(true);

                        studTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        studTextCompList[0].text = reader.GetString(0);
                        studTextCompList[1].text = reader.GetString(1);
                        studTextCompList[2].text = reader.GetString(2);
                        studTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        studTextCompList[3].text = reader.GetString(3);
                        studTextCompList[4].text = reader.GetString(4);
                        studTextCompList[5].text = reader.GetString(5);
                        studTextCompList[6].text = reader.GetString(6);

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
                string sqlQuery = "SELECT TeacherID, Username, Password, Firstname, Middlename, Lastname FROM TeachersTBL";
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
                        userHeader.SetActive(true);

                        teachTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        teachTextCompList[0].text = reader.GetString(0);
                        teachTextCompList[1].text = reader.GetString(1);
                        teachTextCompList[2].text = reader.GetString(2);
                        teachTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        teachTextCompList[3].text = reader.GetString(3);
                        teachTextCompList[4].text = reader.GetString(4);
                        teachTextCompList[5].text = reader.GetString(5);

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
                string sqlQuery = "SELECT StudentID, Username, Password, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
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
                        userHeader.SetActive(true);

                        studTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        studTextCompList[0].text = reader.GetString(0);
                        studTextCompList[1].text = reader.GetString(1);
                        studTextCompList[2].text = reader.GetString(2);
                        studTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        studTextCompList[3].text = reader.GetString(3);
                        studTextCompList[4].text = reader.GetString(4);
                        studTextCompList[5].text = reader.GetString(5);
                        studTextCompList[6].text = reader.GetString(6);

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
                string sqlQuery = "SELECT TeacherID, Username, Password, Firstname, Middlename, Lastname FROM TeachersTBL";
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
                        userHeader.SetActive(true);

                        teachTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        teachTextCompList[0].text = reader.GetString(0);
                        teachTextCompList[1].text = reader.GetString(1);
                        teachTextCompList[2].text = reader.GetString(2);
                        teachTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        teachTextCompList[3].text = reader.GetString(3);
                        teachTextCompList[4].text = reader.GetString(4);
                        teachTextCompList[5].text = reader.GetString(5);

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
                    sqlQuery = "SELECT StudentID, Username, Password, Firstname, Middlename, Lastname, Section FROM StudentsTBL";
                }
                else
                {
                    sqlQuery = "SELECT StudentID, Username, Password, Firstname, Middlename, Lastname, Section FROM StudentsTBL " +
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
                        userHeader.SetActive(true);

                        teachTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        teachTextCompList[0].text = reader.GetString(0);
                        teachTextCompList[1].text = reader.GetString(1);
                        teachTextCompList[2].text = reader.GetString(2);
                        teachTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        teachTextCompList[3].text = reader.GetString(3);
                        teachTextCompList[4].text = reader.GetString(4);
                        teachTextCompList[5].text = reader.GetString(5);
                        teachTextCompList[6].text = reader.GetString(6);

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
                    sqlQuery = "SELECT TeacherID, Username, Password, Firstname, Middlename, Lastname FROM TeachersTBL";
                }
                else
                {
                    sqlQuery = "SELECT TeacherID, Username, Password, Firstname, Middlename, Lastname FROM TeachersTBL " +
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
                        userHeader.SetActive(true);

                        teachTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        teachTextCompList[0].text = reader.GetString(0);
                        teachTextCompList[1].text = reader.GetString(1);
                        teachTextCompList[2].text = reader.GetString(2);
                        teachTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        teachTextCompList[3].text = reader.GetString(3);
                        teachTextCompList[4].text = reader.GetString(4);
                        teachTextCompList[5].text = reader.GetString(5);
                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
    
    public void DisplayStudentArchive()
    {
        // delete all child 
        foreach (Transform child in stArchContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT StudentID, Username, Password, Firstname, Middlename, Lastname, Section FROM StudentsArchiveTBL";
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
                        GameObject userHeader = GameObject.Instantiate(stArchRestoreHeaderPrefab, stArchContentParent.transform);
                        userHeader.SetActive(true);
                        stArchResTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        stArchResTextCompList[0].text = reader.GetString(0);
                        stArchResTextCompList[1].text = reader.GetString(1);
                        stArchResTextCompList[2].text = reader.GetString(2);
                        stArchResTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        stArchResTextCompList[3].text = reader.GetString(3);
                        stArchResTextCompList[4].text = reader.GetString(4);
                        stArchResTextCompList[5].text = reader.GetString(5);
                        stArchResTextCompList[6].text = reader.GetString(6);

                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }

    public void DisplayTeacherArchive()
    {
        // delete all child 
        foreach (Transform child in tArchContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT TeacherID, Username, Password, Firstname, Middlename, Lastname FROM TeachersArchiveTBL";
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
                        GameObject userHeader = GameObject.Instantiate(tArchRestoreHeaderPrefab, tArchContentParent.transform);
                        userHeader.SetActive(true);
                        tArchResTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        //Debug.Log(textCompList[0].gameObject.name);
                        tArchResTextCompList[0].text = reader.GetString(0);
                        tArchResTextCompList[1].text = reader.GetString(1);
                        tArchResTextCompList[2].text = reader.GetString(2);
                        tArchResTextCompList[2].gameObject.transform.parent.gameObject.SetActive(false);

                        tArchResTextCompList[3].text = reader.GetString(3);
                        tArchResTextCompList[4].text = reader.GetString(4);
                        tArchResTextCompList[5].text = reader.GetString(5);

                    }
                    reader.Close();

                }
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
        Debug.Log("Display teacher archive");
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

    public void DisplaySectionArchive()
    {
        // delete all child 
        foreach (Transform child in sArchContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT Sections FROM SectionsArchiveTBL;";

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
                        GameObject userHeader = GameObject.Instantiate(sArchHeaderPrefab, sArchContentParent.transform);
                         userHeader.SetActive(true);
                        sArchTextCompList = userHeader.gameObject.GetComponentsInChildren<TextMeshProUGUI>();

                        sArchTextCompList[0].text = reader.GetString(0);
                       

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

    public void UpdateStudentAccRec()
    {
        DisplayStudentAccRecMain();
        DisplayStudentAccRecPreview();
        DisplayStudentFilteredAccRecMain();
        DisplayStudentArchive();
    }
    public void UpdateTeacherAccRec()
    {
        DisplayTeacherAccRecMain();
        DisplayTeacherAccRecPreview();
        DisplayTeacherFilteredAccRecMain();
        DisplayTeacherArchive();
    }
}
