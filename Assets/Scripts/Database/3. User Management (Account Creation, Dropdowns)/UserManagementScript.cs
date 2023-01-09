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

public class UserManagementScript : MonoBehaviour {
    DropdownUserType dropdownUserType; //empty script reference. 1st
    DropdownSections dropdownSections; //empty script reference. 1st 
    [Header("DROPDOWN SCRIPT REFERENCES")]
    [SerializeField] GameObject DDUserType; //Getting Object Script Component 2nd
    [SerializeField] GameObject DDSection; //Getting Object Script Component 2nd 

    [Header("INPUTFIELD MAIN")]
    public TMP_InputField UserID;
    public TMP_InputField UserName;
    public TMP_InputField Password;
    public TMP_InputField ConfirmPassword;
    public TMP_InputField FirstName;
    public TMP_InputField MiddleName;
    public TMP_InputField LastName;
    [Header("INPUTFIELD SECTIONS")]
    public TMP_InputField IFieldSections;

    [Header("HIDE WHEN USERTYPE SELECTED")]
    public GameObject Section;
    public GameObject lblStudentInformation;
    public GameObject lblTeacherInformation;

    [Header("ERROR MESSAGES")]
    public GameObject UsernameError;
    public GameObject FirstnameError;
    public GameObject LastnameError;
    public GameObject PasswordEmptyError;
    public GameObject PasswordDoNotMatch;
    public GameObject PasswordLengthError;
    public GameObject UserIDisTaken;

    [Header("NOTIFICATIONS")]
    public GameObject SucessfulAccountCreation;

    private string connectionString;
    private string sqlQuery;

    void Awake() { //INITIALIZING REFERENCES TO ACCESS SCRIPTS IN ANOTHER OBJECT
        dropdownUserType = DDUserType.GetComponent<DropdownUserType>(); // 3rd 
        dropdownSections = DDSection.GetComponent<DropdownSections>(); // 3rd
    }
    void Start() {
        //RegisterAccount();
        connectionString = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
    }
    void Update() {
        GetValueUsername();
    }
    public void RegisterAccount2() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                //READING THE DATABASE
                sqlQuery = "SELECT StudentID FROM StudentsTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //TRAP THE SAME USER ID
                        if (UserID.text == reader.GetInt32(0).ToString()) {
                            UserIDisTaken.SetActive(true);
                        }
                        else {
                            UserIDisTaken.SetActive(false);
                        }

                    }
                    //Debug.Log(reader.GetInt32(0));
                    
                    reader.Close();
                }
                sqlQuery = "SELECT TeacherID FROM TeachersTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //TRAP THE SAME USER ID
                        if (UserID.text == reader.GetInt32(0).ToString()) {
                            Debug.Log("Same UserID, Taken!");
                            UserIDisTaken.SetActive(true);
                        }
                        else {
                            UserIDisTaken.SetActive(false);
                        }

                    }
                    //Debug.Log(reader.GetInt32(0));

                    reader.Close();
                }

                //USER ID EMPTY
                if (string.IsNullOrEmpty(UserID.text)) {
                    UsernameError.SetActive(true);
                }
                if (!string.IsNullOrEmpty(UserID.text)) {
                    UsernameError.SetActive(false);
                }
                //FIRST NAME EMPTY
                if (string.IsNullOrEmpty(FirstName.text)) {
                    FirstnameError.SetActive(true);
                }
                if (!string.IsNullOrEmpty(FirstName.text)) {
                    FirstnameError.SetActive(false);
                }

                //LAST NAME EMPTY
                if (string.IsNullOrEmpty(LastName.text)) {
                    LastnameError.SetActive(true);
                }
                if (!string.IsNullOrEmpty(LastName.text)) {
                    LastnameError.SetActive(false);
                }
                //PASSWORD EMPTY
                if (string.IsNullOrEmpty(Password.text)) {
                    PasswordEmptyError.SetActive(true);
                }
                if (!string.IsNullOrEmpty(Password.text)) {
                    PasswordEmptyError.SetActive(false);
                }
                //CONFIRM PASSWORD 
                if (Password.text != ConfirmPassword.text) {
                    PasswordDoNotMatch.SetActive(true);
                }
                if (Password.text == ConfirmPassword.text) {
                    PasswordDoNotMatch.SetActive(false);
                }
                if (!string.IsNullOrEmpty(UserID.text) && !string.IsNullOrEmpty(Password.text) && !string.IsNullOrEmpty(ConfirmPassword.text)
                    &&  !string.IsNullOrEmpty(FirstName.text) && !string.IsNullOrEmpty(LastName.text) && Password.text == ConfirmPassword.text && dropdownUserType.SelectedUserType == ("Teacher")) {
                    
                    
                    
                    string sqlQuery = "INSERT INTO TeachersTBL (TeacherID, Username, Password, Firstname, Middlename, Lastname) " +
                        "VALUES ( '" + UserID.text + "','" + UserName.text + "','" + Password.text + "','" + FirstName.text + "','" + MiddleName.text + "','" + LastName.text + "');";
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    UserID.text = "";
                    UserName.text = "";
                    Password.text = "";
                    ConfirmPassword.text = "";
                    FirstName.text = "";
                    MiddleName.text = "";
                    LastName.text = "";

                    SucessfulAccountCreation.SetActive(true);

                    Debug.Log("Teacher Account create successfully");
                }

                if(!string.IsNullOrEmpty(UserID.text) && !string.IsNullOrEmpty(Password.text) && !string.IsNullOrEmpty(ConfirmPassword.text) 
                    && !string.IsNullOrEmpty(FirstName.text) && !string.IsNullOrEmpty(Password.text) && dropdownUserType.SelectedUserType == ("Student")) {
                    string sqlQuery = "INSERT INTO StudentsTBL (StudentID, Username, Password, Firstname, Middlename, Lastname, Section) " +
                        "VALUES ( '" + UserID.text + "','" + UserName.text + "','" + Password.text + "','" + FirstName.text + "','" 
                        + MiddleName.text + "','" + LastName.text + "','" + dropdownSections.SelectedSection + "');";

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    Debug.Log("Student Account create successfully");
                    UserID.text = "";
                    UserName.text = "";
                    Password.text = "";
                    ConfirmPassword.text = "";
                    FirstName.text = "";
                    MiddleName.text = "";
                    LastName.text = "";

                    SucessfulAccountCreation.SetActive(true);
                }
                dbConnection.Close();
            }
        }
    }
    public void Clear() {
        UserID.text = "";
        UserName.text = "";
        Password.text = "";
        ConfirmPassword.text = "";
        FirstName.text = "";
        MiddleName.text = "";
        LastName.text = "";
        UsernameError.SetActive(false);
        FirstnameError.SetActive(false);
        LastnameError.SetActive(false);
        PasswordDoNotMatch.SetActive(false);
        PasswordEmptyError.SetActive(false);
        PasswordLengthError.SetActive(false);
    }
    public void btnAddSectionClearErrors() {
        UsernameError.SetActive(false);
        FirstnameError.SetActive(false);
        LastnameError.SetActive(false);
        PasswordDoNotMatch.SetActive(false);
        PasswordEmptyError.SetActive(false);
        PasswordLengthError.SetActive(false);
    }

    //ADD SECTION PANEL
    public void AddSection() {
        // string conn = "URI=file:" + Application.dataPath + "/Database/"+"/testdb.db";
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db"; //path to database, will read anything inside assets
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "INSERT INTO SectionsTBL (Sections) VALUES('" + IFieldSections.text + "');";
        Debug.Log("Section is added Successfully!");

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void GetValueUsername() {
        UserName.text = LastName.text + "." + UserID.text;

        if (dropdownUserType.SelectedUserType == "Teacher") {
            Section.SetActive(false);
            lblStudentInformation.SetActive(false);
            lblTeacherInformation.SetActive(true);
        }
        else if (dropdownUserType.SelectedUserType == "Student"){
            Section.SetActive(true);
            lblTeacherInformation.SetActive(false);
            lblStudentInformation.SetActive(true);
            
        }
    }
}


