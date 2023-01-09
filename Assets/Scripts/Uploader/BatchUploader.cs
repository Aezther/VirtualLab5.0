using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.Progress;
using System.IO;
using UnityEditor;
using Unity.VisualScripting;

public class BatchUploader : MonoBehaviour
{
    [Header("Excel File")]
    public TextAsset fileToUpload;

    public string path; //used to search for the file
    string filePath = ""; //used to create the path and file for heatmap

    [Header("UserList Data Scriptable")]
    [SerializeField] UserData userData;


    private int nColumn = 7; // numbe of column in excel file
    private int nUsers = 0; // number of registered users


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
                uploadedUserList.user[counter].ID = int.Parse(dataValues[0]);
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
        if (this.userData == null)
        {
            Debug.Log("Scriptable object for uploaded file not found");
            return;
        }

        this.userData.userList.user = new UserData.User[nUsers]; // create user list array in scriptable 

        for (int i = 0; i < nUsers; i++)
        {
            //SAVING DATA TO SCRIPTABLE OBJECT
            this.userData.userList.user[i] = new UserData.User();

            // transfer data per parameter
            this.userData.userList.user[i].ID = uploadedUserList.user[i].ID;
            this.userData.userList.user[i].username = uploadedUserList.user[i].username;
            this.userData.userList.user[i].password = uploadedUserList.user[i].password;
            this.userData.userList.user[i].firstName = uploadedUserList.user[i].firstName;
            this.userData.userList.user[i].middleName = uploadedUserList.user[i].middleName;
            this.userData.userList.user[i].lastName = uploadedUserList.user[i].lastName;
            this.userData.userList.user[i].section = uploadedUserList.user[i].section;
        }
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Select Part", "", "");
        if (path != null)
        {
            //update filepath 
            filePath = path;
            Debug.Log(filePath);
            CheckCSV(); //verify file content
            ReadCSV(); // read data
        }
        else
        {
            Debug.Log("Invalid path");
        }
    }
}
