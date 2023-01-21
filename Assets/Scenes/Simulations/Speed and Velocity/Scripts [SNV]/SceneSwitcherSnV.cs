using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherSnV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchSpeed()
    {
        SceneManager.LoadScene(6);
    }

    public void switchtoVelocity()
    {
        SceneManager.LoadScene(7);
    }

    public void switchtoQuiz()
    {
        SceneManager.LoadScene(8);
    }

}
