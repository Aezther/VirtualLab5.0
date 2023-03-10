using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        OpenUserManagement();
    }

    // Update is called once per frame
    void Update()
    {
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


}
