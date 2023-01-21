using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using System.Xml.Linq;

public class LogoutScript : MonoBehaviour
{   

    

    private string timeLoggedOut;
    private string sqlQuery;
    private string connectionString;

    
    void Awake(){

    }
    void Start(){
    }

    //LOGOUT FUNCTION
    public void LogoutProceedToLogin(){
        SceneManager.LoadScene("2. Login Screen");
    }


    //MAIN MENU BUTTON
    public void ProceedToMainMenu(){
        SceneManager.LoadScene("3. TeacherDashboard");

        
    }
}
