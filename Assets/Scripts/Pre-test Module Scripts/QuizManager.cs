using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour 
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreText;

    int totalQuestions; // counts the total questions that we have in a quiz
    public int score; //counts the total score
    private void Start() {
        totalQuestions= QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    //To Restart the Quiz
    public void retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Once the game ended, it hides the quizpanel and opens the GoPanel
    void GameOver() {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }
    public void correct() {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    //method when answered wrong questions
    public void wrong () {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }


    void SetAnswers() {

        ButtonManager.instance.ResetAllToDefault();
        for (int i = 0; i < options.Length; i++) 
        {
            //reset correct answer
            options[i].GetComponent<AnswerScript>().isCorrect = false; 
            //update choices
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].AnswerChoices[i];

            //set correct answer
            if (QnA[currentQuestion].CorrectAnswer == i + 1) 
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion() {

        if (QnA.Count > 0) 
        {
            //rand question
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else 
        {
            Debug.Log("Out of Questions");
            Debug.Log("Your score is " + score + "!");
            GameOver();
        }

    }
}
