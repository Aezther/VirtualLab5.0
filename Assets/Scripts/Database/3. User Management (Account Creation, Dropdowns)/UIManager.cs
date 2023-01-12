using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    [Header("User Interface")]
    [SerializeField] GameObject logSessionPanel;
    [SerializeField] GameObject createAccountPanel;

    [SerializeField] Button createAccButton;
    [SerializeField] Button logRecordsButton;
    [SerializeField] GameObject refreshButton;


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
        refreshButton.SetActive(false);
        logRecordsButton.interactable = true;
        createAccButton.interactable = false;

        createAccountPanel.SetActive(true);
        logSessionPanel.SetActive(false);
    }
}
