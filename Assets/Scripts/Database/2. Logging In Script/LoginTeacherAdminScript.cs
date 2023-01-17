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
    [SerializeField] TeacherInfo teacherInfo;
    //get time
    private string timeLoggedIn;

    void Start()
    {
        //connectionString = "Data Source = C:\\Users\\Ian\\OneDrive\\Documents\\VirtualLab\\VirtualLab.db";
        connectionString = "Data Source = C:\\Users\\oliva\\Documents\\VirtualLab\\VirtualLab.db";

    }


    public void AdminLogin(){
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
                
                //Start
                sqlQuery = "SELECT Username FROM AdminsAccTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        //empty username
                        string DBUsername = reader.GetString(0);
                        if (string.IsNullOrEmpty(userInput.text)){
                            userError.text = "";
                            userError.text = "Username is empty.";
                        }
                        //invalid input
                        if (DBUsername != userInput.text && !string.IsNullOrEmpty(userInput.text)){
                            userError.text = "";
                            userError.text = "Invalid username.";
                        }
                    }
                    reader.Close();
                }
                //End
                //Start
                sqlQuery = "SELECT Password FROM AdminsAccTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        //empty password
                        string DBPassword = reader.GetString(0);
                        if (string.IsNullOrEmpty(passInput.text)){
                            passError.text = "";
                            passError.text = "Password is empty.";
                        }
                        //invalid input
                        if (DBPassword != passInput.text && !string.IsNullOrEmpty(passInput.text)){
                            passError.text = "";
                            passError.text = "Invalid password.";
                        }
                    }
                    reader.Close();
                }
                //End
                //Start
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
                        teacherInfo.TeacherID = reader.GetString(0);
                        // set scriptable value
                        Debug.Log(teacherInfo.TeacherID);
                    }
                    reader.Close();
                }
                dbConnection.Close();
            }
        }
    }

    public void TeacherLogin() {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand()) {

                //Start
                sqlQuery = "SELECT Username FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //empty username
                        string DBUsername = reader.GetString(0);
                        if (string.IsNullOrEmpty(userInput.text)) {
                            userError.text = "";
                            userError.text = "Username is empty.";
                        }
                        //invalid input
                        if (DBUsername != userInput.text && !string.IsNullOrEmpty(userInput.text)) {
                            userError.text = "";
                            userError.text = "Invalid username.";
                        }
                    }
                    reader.Close();
                }
                //End
                //Start
                sqlQuery = "SELECT Password FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader()) {
                    while (reader.Read()) {
                        //empty password
                        string DBPassword = reader.GetString(0);
                        if (string.IsNullOrEmpty(passInput.text)) {
                            passError.text = "";
                            passError.text = "Password is empty.";
                        }
                        //invalid input
                        if (DBPassword != passInput.text && !string.IsNullOrEmpty(passInput.text)) {
                            passError.text = "";
                            passError.text = "Invalid password.";
                        }
                    }
                    reader.Close();
                }
                //End
                //Start
                //SUCCESSFUL LOGIN
                sqlQuery = "SELECT Username, Password FROM TeachersTBL;";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string DBUsername = reader.GetString(0);
                        string DBPassword = reader.GetString(1);
                        //Successfull login
                        if (DBUsername.Equals(userInput.text) && DBPassword.Equals(passInput.text) && !string.IsNullOrEmpty(passInput.text) && !string.IsNullOrEmpty(userInput.text))
                        {
                            userError.text = "";
                            passError.text = "";
                            StartCoroutine(LoadScenes("3. TeacherDashboard"));

                            Debug.Log("Admin Successful Login! Welcome! ");
                            GetTeacherID();
                        }
                    }
                    reader.Close();
                    //timeLoggedIn = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss tt");
                    //sqlQuery = "INSERT INTO TeacherSessionsTBL (Action, Time, TeacherID) VALUES ('Log in','" + timeLoggedIn + "','" + teacherInfo.TeacherID + "');";
                    //Debug.Log(timeLoggedIn + teacherInfo.TeacherID);
                    ////sqlQuery = "INSERT INTO SectionsTBL (Sections) VALUES('Carlo');";
                    //dbCmd.CommandText = sqlQuery;
                    //dbCmd.ExecuteNonQuery();
                }
                //End
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
