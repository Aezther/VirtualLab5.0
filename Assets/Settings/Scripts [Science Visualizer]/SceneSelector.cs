using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{

    public void selectMainScene()
    {
        SceneManager.LoadScene(0); /// 0 is the index for the main scene

    }

    public void selectTypesofFaults()
    {
        SceneManager.LoadScene(1); /// 1 is the index for Types of Faults
    }

    public void selectPostTestforToF()
    {
        SceneManager.LoadScene(2); /// is the index for the Post Test
    }

    public void selectDistanceandDisplacement()
    {
        SceneManager.LoadScene(3); /// is the index for Distance and Displacement
    }

    public void selectPostTestforDND()
    {
        SceneManager.LoadScene(5); /// is the index for the Post Test
    }

    public void selectSpeedandVelocity()
    {
        SceneManager.LoadScene(6); /// is the index for Speed and Velocity
    }


}
