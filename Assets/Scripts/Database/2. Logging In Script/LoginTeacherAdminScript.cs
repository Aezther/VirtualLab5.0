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
    public TMP_InputField userInput;
    public TMP_InputField passInput;
    void Start()
    {
        LoginAdmin();
    }
    public void LoginAdmin() {
        string conn = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db"; //path to database, will read anything inside assets
        IDbConnection dbconn;//established a connection
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //open connection to the database
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Username, Password FROM AdminsAccTBL;";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            if (reader["Username"].Equals(userInput.text) && reader["Password"].Equals(passInput.text)) {
                StartCoroutine(LoadScenes("3. Admin Dashboard"));

                Debug.Log("Successful Login! Welcome! ");
            }
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    public void LoginTeacher() {

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
