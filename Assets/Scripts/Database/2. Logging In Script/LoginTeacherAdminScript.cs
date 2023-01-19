using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginTeacherAdminScript : MonoBehaviour
{
    public Animator transition;
    [Header ("InputFields")]
    public TMP_InputField userInput;
    public TMP_InputField passInput;

    [Header("Error Messages")]
    public TextMeshProUGUI userError;
    public TextMeshProUGUI passError;
    private string connectionString;
    private string sqlQuery;
    //get teacher id
    private string TeacherIDInfo;
    //get time
    private string timeLoggedIn;
    [SerializeField] TeacherInfo teacherInfo;
    void Start()
    {
        //connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        connectionString = "Data Source = C:\\Users\\oliva\\Documents\\VirtualLab\\VirtualLab.db";
    }


    public void AdminLogin(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                //start
                sqlQuery = "SELECT Username, Password FROM AdminsAccTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        string DBUsername = reader.GetString(0);
                        string DBPassword = reader.GetString(1);
                        //Successfull login
                        if (DBUsername.Equals (userInput.text) && DBPassword.Equals(passInput.text) && !string.IsNullOrEmpty(passInput.text) && !string.IsNullOrEmpty(userInput.text)){
                            userError.text = "";
                            passError.text = "";
                            StartCoroutine(LoadScenes("6. Admin Dashboard"));

                            Debug.Log("Admin Successful Login! Welcome! ");
                           
                        }
                    }
                    reader.Close();
                }
                //End
            }
            dbConnection.Close();
        }
    }

    

    public void GetTeacherID() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                //start
                sqlQuery = "SELECT TeacherID FROM TeachersTBL WHERE Username = '" + userInput.text + "';";
                //sqlQuery = "INSERT INTO StudentSessionsTBL (Action, Time, StudentID) VALUES ('Login','wawawa','1');";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        TeacherIDInfo = reader.GetString(0);
                        //teacherInfo.TeacherID;
                        teacherInfo.TeacherID = TeacherIDInfo;
                        Debug.Log(TeacherIDInfo);
                    }
                    reader.Close();
                }
                dbConnection.Close();
            }
        }
    }
    public void GetTeacherCredentials(){
        using (IDbConnection dbConnection = new SqliteConnection (connectionString)){
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                sqlQuery = "SELECT Firstname, Lastname FROM TeachersTBL WHERE Username = '" + userInput.text + "';";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        string Firstname = reader.GetString(0);
                        string Lastname = reader.GetString(1);
                        Debug.Log("Your name is " +Firstname+"," + Lastname );
                        teacherInfo.TeacherFullname = Firstname+ " " + Lastname;
                        //userInput.StudentName = Firstname.First().ToString().ToUpper() + Firstname.Substring(1) + " " + Lastname.First().ToString().ToUpper() + Lastname.Substring(1);
                    }
                    reader.Close();
                }
                dbConnection.Close();
            }
        }
    }
    public void TeacherLogin() {
        VerifyUsernameTeacher();
        VerifyPasswordTeacher();
        VerifyBothUserPass();
    }
    public void VerifyUsernameTeacher(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                sqlQuery = "SELECT Username FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //empty username
                        string DBUsername = reader.GetString(0);
                        if (string.IsNullOrEmpty(userInput.text)) {
                            userError.text = "Username is empty.";
                            return;
                        }else{
                            userError.text = "";
                        }
                        //invalid input
                        if (DBUsername != userInput.text && !string.IsNullOrEmpty(userInput.text)) {
                            userError.text = "Invalid username.";
                            return;
                        }else{
                            userError.text = "";
                        }
                    }
                    reader.Close();
                }
            }
            dbConnection.Close();
        }
    }
    public void VerifyPasswordTeacher(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                sqlQuery = "SELECT Password FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //empty password
                        string DBPassword = reader.GetString(0);
                        if (string.IsNullOrEmpty(passInput.text)) {
                            passError.text = "Password is empty.";
                            return;
                        }else{
                            passError.text = "";
                        }
                        //invalid input
                        if (DBPassword != passInput.text && !string.IsNullOrEmpty(passInput.text)) {
                            passError.text = "Invalid password.";
                            return;
                        }else{
                            passError.text = "";
                        }
                    }
                    reader.Close();
                }
            }
            dbConnection.Close();
        }
    }
    public void VerifyBothUserPass(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                                sqlQuery = "SELECT Username, Password FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        string DBUsername = reader.GetString(0);
                        string DBPassword = reader.GetString(1);
                        //Successfull login
                        if (DBUsername.Equals(userInput.text) && DBPassword.Equals(passInput.text) && !string.IsNullOrEmpty(passInput.text) && !string.IsNullOrEmpty(userInput.text)) {
                            
                            StartCoroutine(LoadScenes("3. TeacherDashboard"));
                            userError.text = "";
                            passError.text = "";
                            GetTeacherCredentials();
                            //Debug.Log("Teacher Successful Login! Welcome! ");
                            GetTeacherID();
                        }
                    }
                    reader.Close();
                //    timeLoggedIn = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss tt");
                //    sqlQuery = "INSERT INTO TeacherSessionsTBL (Action, Time, TeacherID) VALUES ('Log in','" + timeLoggedIn + "','" + TeacherIDInfo + "');";
                //    Debug.Log(timeLoggedIn + TeacherIDInfo);
                //    //sqlQuery = "INSERT INTO SectionsTBL (Sections) VALUES('Carlo');";
                //    dbCmd.CommandText = sqlQuery;
                //    dbCmd.ExecuteNonQuery();
                }
            }
            dbConnection.Close();
        }
    }

    IEnumerator LoadScenes(string SceneIndex) //to control the speed of the transition
{
        //play the animation using trigger
        transition.SetTrigger("Start");

        //Animation Transition Time speed
        yield return new WaitForSeconds(1f);

        //load the scene
        SceneManager.LoadScene(SceneIndex);
    }
}
