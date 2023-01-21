using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class AnswerScript : MonoBehaviour
{
    public bool isSelected = false;
    public bool isCorrect = false;
    
    public QuizManager quizManager;

    public void SelectAnswer()
    {
        ButtonManager.instance.ResetAllToDefault();
        isSelected = true;
        GetComponent<Button>().interactable = false;
        ButtonManager.instance.UpdateSubmitButton();


    }

    public void Answer() {
        if (isCorrect) {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
        Debug.Log("Selected: " + this.gameObject.name);
    }
}
