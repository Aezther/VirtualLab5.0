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
using System.Text.RegularExpressions;

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
    public TextMeshProUGUI UserIDError;
    public TextMeshProUGUI passError;
    public TextMeshProUGUI conpassError;
    public TextMeshProUGUI firstNameError;
    public TextMeshProUGUI lastnameError;
    public TextMeshProUGUI sectionError;

    [Header("NOTIFICATIONS")]
    public GameObject SucessfulAccountCreation;

    private string connectionString;
    private string sqlQuery;

    //Get teacher and student ID
    private string DBStudentID;
    private string DBTeacherID;



    void Awake() { //INITIALIZING REFERENCES TO ACCESS SCRIPTS IN ANOTHER OBJECT
        dropdownUserType = DDUserType.GetComponent<DropdownUserType>(); // 3rd 
        dropdownSections = DDSection.GetComponent<DropdownSections>(); // 3rd
    }
    void Start() {
        connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
    }
    void Update() {
        GetValueUsername();
    }

    public void Validation (){
        UserIDValidation();
        passwordValidation();
        ConfirmPassValidation();
        FirstNameValidation();
        LastNameValidation();
        //SuccessfullLogin();
        SuccessfullRegistration();
    }
    public void UserIDValidation() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //--------------------USER ID------------------------
                //TRAP SAME STUDENTID IN STUDENT ACCOUNT CREATION.
                sqlQuery = "SELECT StudentID FROM StudentsTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        DBStudentID = reader.GetString(0);
                        //Debug.Log(reader.GetString(0));

                        if (dropdownUserType.SelectedUserType == "Student" && UserID.text ==DBStudentID){
                            UserIDError.text = "Student ID is taken.";
                            return;
                        }else{
                            UserIDError.text = "";
                        }
                    }   
                    reader.Close();
                }
                //TRAP SAME TEACHERID IN TEACHER ACCOUNT CREATION.
                sqlQuery = "SELECT TeacherID FROM TeachersTBL";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        DBTeacherID = reader.GetString(0);
                        //Debug.Log(DBStudentID);
                        //Debug.Log(reader.GetString(0))
                        //Debug.Log(reader.GetString(0));
                        if (dropdownUserType.SelectedUserType == "Teacher" && UserID.text ==DBTeacherID){
                            UserIDError.text = "Teacher ID is taken.";
                            return;
                        }else{
                             UserIDError.text = "";
                        }
                    }
                    reader.Close();
                }
                //USERID EMPTY
                if (string.IsNullOrEmpty(UserID.text)){
                    UserIDError.text = "";
                    UserIDError.text = "User ID is empty.";
                    return;
                }else{
                    UserIDError.text = "";
                }
                //USERID SPACES
                if (string.IsNullOrWhiteSpace(UserID.text.Trim())){
                    UserIDError.text = "";
                    UserIDError.text = "User ID contains spaces.";
                    return;
                }else {
                    UserIDError.text = "";
                }
                //USERID DOESN'T ACCEPT WHITE SPACES
                if (Regex.IsMatch(UserID.text, @"\s")) {
                    UserIDError.text = "Input contains whitespace.";
                    return;
                }else{
                    UserIDError.text = "";
                }
                if (!Regex.IsMatch(UserID.text, "^[a-zA-Z0-9]+$")) {
                    UserIDError.text = "Invalid Characters.";
                }else {
                    UserIDError.text = "";
                }
                dbConnection.Close();
            }
        }
    }
    public void passwordValidation(){
        if (string.IsNullOrEmpty(Password.text)){
            passError.text = "Password field is empty.";
            return;
        }else{
             passError.text ="";
        }
        if (string.IsNullOrWhiteSpace(Password.text.Trim())){
            passError.text = "Password contains spaces.";
            return;
        }else{
            passError.text ="";
        }
        if (Password.text.Length < 8){
            passError.text = "Password must be at least 8 characters long.";
        }else{
            passError.text ="";
        }
    }
    public void ConfirmPassValidation(){
        if (string.IsNullOrEmpty(ConfirmPassword.text)){
            conpassError.text = "Confirm Password field is empty.";
            return;
        }else{
            conpassError.text ="";
        }
        if (string.IsNullOrWhiteSpace(ConfirmPassword.text.Trim())){
            conpassError.text = "Confirm Password contains spaces.";
            return;
        }else{
            conpassError.text ="";
        }

        if (Password.text != ConfirmPassword.text){
            conpassError.text = "Passwords do not match.";
            return;
        } 
    }
    public void FirstNameValidation(){
        if (string.IsNullOrEmpty(FirstName.text)){
            firstNameError.text = "Firstname is Empty.";
            return;
        }else{
            firstNameError.text ="";
        }
        if (string.IsNullOrWhiteSpace(FirstName.text)){
            firstNameError.text = "Firstname contains spaces.";
            return;
        }else {
            firstNameError.text ="";
        }
        if (!Regex.IsMatch(FirstName.text, "^[a-zA-Z0-9 ]*$")) {
            firstNameError.text = "Invalid Characters.";
        }
        else {
            firstNameError.text = "";
        }
    }
    public void LastNameValidation(){
        if (string.IsNullOrEmpty(LastName.text)){
            lastnameError.text = "Lastname is Empty.";
            return;
        }else{
            lastnameError.text ="";
        }
        if (string.IsNullOrWhiteSpace(LastName.text)){
            lastnameError.text = "Lastname contains spaces.";
            return;
        }else {
            lastnameError.text ="";
        }
        if (!Regex.IsMatch(LastName.text, "^[a-zA-Z0-9 ]+$")) {
            lastnameError.text = "Invalid Characters.";
        }
        else {
            lastnameError.text = "";
        }
    }
    public void SuccessfullRegistration(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                //STUDENTS
                if ((dropdownUserType.SelectedUserType == ("Student")) &&((dropdownUserType.SelectedUserType == "Student" && UserID.text != DBStudentID)) && (!string.IsNullOrEmpty(UserID.text)) &&
                    (!string.IsNullOrWhiteSpace(UserID.text.Trim())) && (!Regex.IsMatch(UserID.text, @"\s")) && (Regex.IsMatch(UserID.text, "^[a-zA-Z0-9]+$")) &&
                    (!string.IsNullOrEmpty(Password.text)) && (!string.IsNullOrWhiteSpace(Password.text.Trim())) && (Password.text.Length > 8) &&
                    (!string.IsNullOrEmpty(ConfirmPassword.text)) && (!string.IsNullOrWhiteSpace(ConfirmPassword.text.Trim())) && (Password.text == ConfirmPassword.text) &&
                    (!string.IsNullOrEmpty(FirstName.text)) && (!string.IsNullOrWhiteSpace(FirstName.text)) && (Regex.IsMatch(FirstName.text, "^[a-zA-Z0-9 ]+$")) &&
                    (!string.IsNullOrEmpty(LastName.text)) && (!string.IsNullOrWhiteSpace(LastName.text)) && (Regex.IsMatch(LastName.text, "^[a-zA-Z0-9 ]+$"))) {

                    Debug.Log("Success!");

                    //start
                    sqlQuery = "INSERT INTO StudentsTBL (StudentID, Username, Password, Firstname, Middlename, Lastname, Section) VALUES ( '" +
                        UserID.text + "','" + 
                        UserName.text + "','" + 
                        Password.text + "','" + 
                        FirstName.text + "','" + 
                        MiddleName.text + "','" + 
                        LastName.text + "','" + 
                        dropdownSections.SelectedSection + "');";
                    Debug.Log("Student Account has been created!");
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteNonQuery();

                    SucessfulAccountCreation.SetActive(true);
                    //end
                    UserID.text = "";
                    UserName.text = "";
                    Password.text = "";
                    ConfirmPassword.text = "";
                    FirstName.text = "";
                    MiddleName.text = "";
                    LastName.text = "";
                }

                //TEACHER
                if ((dropdownUserType.SelectedUserType == ("Teacher")) &&((dropdownUserType.SelectedUserType == "Teacher" && UserID.text != DBTeacherID)) && (!string.IsNullOrEmpty(UserID.text)) &&
                    (!string.IsNullOrWhiteSpace(UserID.text.Trim())) && (!Regex.IsMatch(UserID.text, @"\s")) && (Regex.IsMatch(UserID.text, "^[a-zA-Z0-9]+$")) &&
                    (!string.IsNullOrEmpty(Password.text)) && (!string.IsNullOrWhiteSpace(Password.text.Trim())) && (Password.text.Length > 8) &&
                    (!string.IsNullOrEmpty(ConfirmPassword.text)) && (!string.IsNullOrWhiteSpace(ConfirmPassword.text.Trim())) && (Password.text == ConfirmPassword.text) &&
                    (!string.IsNullOrEmpty(FirstName.text)) && (!string.IsNullOrWhiteSpace(FirstName.text)) && (Regex.IsMatch(FirstName.text, "^[a-zA-Z0-9 ]+$")) &&
                    (!string.IsNullOrEmpty(LastName.text)) && (!string.IsNullOrWhiteSpace(LastName.text)) && (Regex.IsMatch(LastName.text, "^[a-zA-Z0-9 ]+$"))) {

                    Debug.Log("Success!");

                    //start
                    sqlQuery = "INSERT INTO TeachersTBL (TeacherID, Username, Password, Firstname, Middlename, Lastname) VALUES ( '" + 
                        UserID.text + "','" + 
                        UserName.text + "','" + 
                        Password.text + "','" + 
                        FirstName.text + "','" + 
                        MiddleName.text + "','" + 
                        LastName.text + "');";
                    Debug.Log("Teacher Account has been created!");

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteNonQuery();

                    SucessfulAccountCreation.SetActive(true);
                    //end
                    UserID.text = "";
                    UserName.text = "";
                    Password.text = "";
                    ConfirmPassword.text = "";
                    FirstName.text = "";
                    MiddleName.text = "";
                    LastName.text = "";
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

    }
    public void btnAddSectionClearErrors() {

    }
    //ADD SECTION PANEL
    public void AddSection() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                sqlQuery = "INSERT INTO SectionsTBL (Sections) VALUES('" + IFieldSections.text + "');";
                Debug.Log("Section is added Successfully!");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
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


