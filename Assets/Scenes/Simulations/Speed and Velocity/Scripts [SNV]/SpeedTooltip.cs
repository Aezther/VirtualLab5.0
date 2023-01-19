using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedTooltip : MonoBehaviour
{
    public TMP_Text speedDefinition;
    public TMP_Text velocityDefinition;
    public Canvas velDirection;
    public Canvas velDirBG;
    private bool speedtoggle = false;
    private bool velocitytoggle = false;

    private void Start()
    {
        velocityDefinition.gameObject.SetActive(false);
        velDirection.gameObject.SetActive(false); ;
        velDirBG.gameObject.SetActive(false);
    }

    public void speedTooltip()
    {
        if (!speedDefinition.isActiveAndEnabled)
        {
            speedtoggle = false;
        }

        if (speedtoggle == false)
        {
            velocityDefinition.gameObject.SetActive(false);
            speedtoggle = true;
            speedTooltipToggl();

        }
        else
        {
            speedtoggle = false;
            speedTooltipToggl();
        }
    }

    void speedTooltipToggl()
    {
        if (speedtoggle == true)
        {
            speedDefinition.gameObject.SetActive(true);
            velDirection.gameObject.SetActive(false); ;
            velDirBG.gameObject.SetActive(false);
        }

    }

    ///////////////////////////////////////////////

    public void velocityTooltip()
    {
        if (!velocityDefinition.isActiveAndEnabled)
        {
            velocitytoggle = false;
        }

        if (velocitytoggle == false)
        {
            speedDefinition.gameObject.SetActive(false);
            velocitytoggle = true;
            velocityTooltipToggl();
        }


    }

    void velocityTooltipToggl()
    {
        if (velocitytoggle == true)
        {
            velocityDefinition.gameObject.SetActive(true);
            velDirection.gameObject.SetActive(true); ;
            velDirBG.gameObject.SetActive(true);
        }

    }

}
   

