using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{

    public GameObject objHeader;
    public GameObject objMission;
    public GameObject objCounter;
    public GameObject resetButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjShow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator ObjShow()
    {
        yield return new WaitForSeconds(2f);

        objHeader.SetActive(true);
        Debug.Log("test");
        
        yield return new WaitForSeconds(3f);

        objHeader.SetActive(false);
        objMission.SetActive(true);
        
        yield return new WaitForSeconds(1f);

        objCounter.SetActive(true);

    }

    public void restartGame()
    {
        SceneManager.LoadScene("RoboDistance");
    }

}
