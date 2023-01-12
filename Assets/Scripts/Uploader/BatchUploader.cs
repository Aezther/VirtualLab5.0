using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;
using SFB;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Collections.Specialized.BitVector32;

public class BatchUploader : MonoBehaviour
{
    [Header("Excel File")]
    [SerializeField] TextMeshProUGUI filename;
    [SerializeField] Button uploadButton;


    public string path; //used to search for the file
    string filePath = ""; //used to create the path and file for heatmap

    [Header("UserList Data Scriptable")]
    [SerializeField] UserData loadedData;


    private int nColumn = 7; // numbe of column in excel file
    private int nUsers = 0; // number of registered users
    private string connectionString;
    private string sqlQuery;


    [System.Serializable]
    public class User
    {
        // user attributes
        public int ID;
        public string username;
        public string password;
        public string firstName;
        public string middleName;
        public string lastName;
        public string section;
    }

    [System.Serializable]
    public class UserList
    {
        // user instance
        public User[] user;
    }

    public UserList uploadedUserList = new UserList();

    // Start is called before the first frame update
    void Start()
    {
        connectionString = "URI=file:" + Application.streamingAssetsPath + "/Database/" + "/VirtualDB.db";
    }

    public void CheckCSV()
    {
        //READ FILE FROM FILEPATH

        StreamReader strReader = new StreamReader(filePath);
        bool isEOF = false;
        nUsers = 0;

        while (isEOF == false)  // reads every word
        {
            string dataString = strReader.ReadLine();
            if (dataString == null)
            {
                isEOF = true;
                break;
            }
            var dataValues = dataString.Split(',');
            nColumn = dataValues.Length;

            // uncomment for debugging
            //Debug.Log
            //(   dataValues[0].ToString() + " " + 
            //    dataValues[1].ToString() + " " + 
            //    dataValues[2].ToString() + " " + 
            //    dataValues[3].ToString() + " " + 
            //    dataValues[4].ToString() + " " + 
            //    dataValues[5].ToString() + " " + 
            //    dataValues[6].ToString()
            //);  

            nUsers++;

        }
        nUsers -= 1;

        ReadCSV();
    }

    public void ReadCSV()
    {
        StreamReader strReader = new StreamReader(filePath);
        bool isEOF = false;
        int counter = -1;

        uploadedUserList.user = new User[nUsers]; // create user list array in scriptable 

        while (isEOF == false)
        {
            string dataString = strReader.ReadLine();
            if (dataString == null)
            {
                isEOF = true;
                break;
            }

            var dataValues = dataString.Split(',');

            // uncomment for debugging
            //Debug.Log
            //(
            //    dataValues[0].ToString() + " " +
            //    dataValues[1].ToString() + " " +
            //    dataValues[2].ToString() + " " +
            //    dataValues[3].ToString() + " " +
            //    dataValues[4].ToString() + " " +
            //    dataValues[5].ToString() + " " +
            //    dataValues[6].ToString()
            //);

            if (counter > -1 && counter < nUsers)
            {
                //READING DATA FROM FILE
                uploadedUserList.user[counter] = new User();

                // transfer data per parameter

                if((string.Join("", dataValues[0]))!=" ")
                {
                    uploadedUserList.user[counter].ID = Convert.ToInt32(dataValues[0]);
                }
                uploadedUserList.user[counter].username = dataValues[1];
                uploadedUserList.user[counter].password = dataValues[2];
                uploadedUserList.user[counter].firstName = dataValues[3];
                uploadedUserList.user[counter].middleName = dataValues[4];
                uploadedUserList.user[counter].lastName = dataValues[5];
                uploadedUserList.user[counter].section = dataValues[6];

            }

            counter++;
        }
    }

    public void WriteCSV()
    {

    }

    public void LoadCSV()
    {
        if (this.loadedData == null)
        {
            Debug.Log("Scriptable object for uploaded file not found");
            return;
        }

        this.loadedData.userList.user = new UserData.User[nUsers]; // create user list array in scriptable 

        for (int i = 0; i < nUsers; i++)
        {
            //SAVING DATA TO SCRIPTABLE OBJECT
            this.loadedData.userList.user[i] = new UserData.User();

            // transfer data per parameter
            this.loadedData.userList.user[i].ID = uploadedUserList.user[i].ID;
            this.loadedData.userList.user[i].username = uploadedUserList.user[i].username;
            this.loadedData.userList.user[i].password = uploadedUserList.user[i].password;
            this.loadedData.userList.user[i].firstName = uploadedUserList.user[i].firstName;
            this.loadedData.userList.user[i].middleName = uploadedUserList.user[i].middleName;
            this.loadedData.userList.user[i].lastName = uploadedUserList.user[i].lastName;
            this.loadedData.userList.user[i].section = uploadedUserList.user[i].section;
        }

        UploadLoadeDataToSQL();
    }

    public void OpenExplorer()
    {
        // Open file with filter
        var extensions = new[]
        {
            new ExtensionFilter("CSV", "csv" ),
        };

        path = string.Join("", StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
        //path = EditorUtility.OpenFilePanel("Select Part", "", "");
        if (!string.IsNullOrEmpty(path))
        {
            //update filepath 
            filePath = path;
            Debug.Log(filePath);
            filename.text = Path.GetFileName(filePath);

            if (System.IO.File.Exists(filePath))
            {
                // File exists
                CheckCSV(); //verify file content
                ReadCSV(); // read data
                uploadButton.interactable = true;
            }
            else
            {
                // File does not exist
                Debug.Log("No file selected");
                uploadButton.interactable = false;
                filename.text = " ";


            }
        }
        else
        {
            Debug.Log("Invalid path");
            filename.text = " ";
            uploadButton.interactable = false;


        }
    }

    public void UploadLoadeDataToSQL()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            // create queries
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                for (int i = 0; i < loadedData.userList.user.Length; i++)
                {
                    UserData.User studentData = loadedData.userList.user[i];

                    string sqlQuery = "INSERT INTO StudentsTBL (StudentID, Username, Password, Firstname, Middlename, Lastname, Section) " +

                   "VALUES ( '" + studentData.ID + "','" +
                                  studentData.username + "','" +
                                  studentData.password + "','" +
                                  studentData.firstName + "','" +
                                  studentData.middleName + "','" +
                                  studentData.lastName + "','" +
                                  studentData.section + "');";

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                }
            }
            dbConnection.Close();
            Debug.Log("Data has been uploaded to DATABASE");
        }

    }
}
