using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Singleton class
    public static ButtonManager instance; // A

    public GameObject[] optionsButtons;
    [SerializeField] Button submitButton;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetAllToDefault()
    {
        // set all buttons to interactable
        for (int i = 0; i < optionsButtons.Length; i++)
        {
            optionsButtons[i].GetComponent<AnswerScript>().isSelected = false;
            optionsButtons[i].GetComponent<Button>().interactable = true;
        }

        submitButton.interactable = false;
    }

    public void SubmitSelectedAnswer()
    {
        for (int i = 0; i < optionsButtons.Length; i++)
        {
            if (optionsButtons[i].GetComponent<AnswerScript>().isSelected)
            {
                optionsButtons[i].GetComponent<AnswerScript>().Answer();
            }
            
        }
    }

    public bool HasSelectedAnswer()
    {
        for (int i = 0; i < optionsButtons.Length; i++)
        {
            if (optionsButtons[i].GetComponent<AnswerScript>().isSelected)
            {
                return true;
            }

        }
        return false;
    }

    public void UpdateSubmitButton()
    {
        submitButton.interactable = HasSelectedAnswer();
    }

}
