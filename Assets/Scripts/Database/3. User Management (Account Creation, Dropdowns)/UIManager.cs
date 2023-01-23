using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [Header("User Interface")]
    [SerializeField] GameObject logSessionPanel;
    [SerializeField] GameObject createAccountPanel;

    [SerializeField] GameObject maximizedAccRecordPanel;


    [SerializeField] Button createAccButton;
    [SerializeField] Button logRecordsButton;
    [SerializeField] GameObject refreshButton;

    [SerializeField] Button[] lessonButtonsList;

    [Header("Edit Student User Reference")]
    [SerializeField] StudentArchiveData currStudent;

    [SerializeField] TextMeshProUGUI[] editRefDisplay;

    [SerializeField] TMP_InputField newUsername;
    [SerializeField] TMP_InputField IDinput;
    [SerializeField] TMP_InputField lastNameInput;

    [Header("Edit Teacher User Reference")]
    [SerializeField] TeacherArchiveData currTeacher;

    [SerializeField] TextMeshProUGUI[] editTeachRefDisplay;

    [SerializeField] TMP_InputField newTchUsername;
    [SerializeField] TMP_InputField tchIDinput;
    [SerializeField] TMP_InputField tchlastNameInput;

    [SerializeField] TMP_InputField[] InputFieldsList;





    // Start is called before the first frame update
    void Start()
    {
        OpenUserManagement();
    }

    // Update is called once per frame
    void Update()
    { 
            newUsername.text = IDinput.text + "." + lastNameInput.text;
            if(SceneManager.GetActiveScene().name == "4. Admin UserManagement"){
            newTchUsername.text = tchIDinput.text + "." + tchlastNameInput.text;
            }
    }


    public void OpenLogRecords()
    {
        refreshButton.SetActive(true);
        logRecordsButton.interactable = false;
        createAccButton.interactable = true;

        createAccountPanel.SetActive(false);
        logSessionPanel.SetActive(true);
    }

    public void OpenUserManagement()
    {
        if (refreshButton && logRecordsButton && createAccButton && createAccountPanel && logSessionPanel)
        {
            refreshButton.SetActive(false);
            logRecordsButton.interactable = true;
            createAccButton.interactable = false;

            createAccountPanel.SetActive(true);
            logSessionPanel.SetActive(false);
        }
 
    }

    public void OpenMaximizedAccRecs()
    {
        createAccountPanel.SetActive(false);
        maximizedAccRecordPanel.SetActive(true);

    }

    public void CloseMaximizedAccRecs()
    {
        createAccountPanel.SetActive(true);
        maximizedAccRecordPanel.SetActive(false);

    }

    public void DisplayRefUserValues()
    {
       editRefDisplay[0].text = currStudent.id ;
       editRefDisplay[1].text = currStudent.username; 
       editRefDisplay[2].text = currStudent.section;
       editRefDisplay[3].text = currStudent.firstname;
       editRefDisplay[4].text = currStudent.middlename;
       editRefDisplay[5].text = currStudent.lastname;
    }

    public void DisplayTeacherRefUserValues()
    {
        editTeachRefDisplay[0].text = currTeacher.id;
        editTeachRefDisplay[1].text = currTeacher.username;
        editTeachRefDisplay[2].text = currTeacher.firstname;
        editTeachRefDisplay[3].text = currTeacher.middlename;
        editTeachRefDisplay[4].text = currTeacher.lastname;
    }

    public void ClearInputfields()
    {
        for (int i = 0; i < InputFieldsList.Length; i++)
        {
            InputFieldsList[i].text = "";
        }
    }


}
