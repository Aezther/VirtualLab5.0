using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Speed : MonoBehaviour
{

    NavMeshAgent agent;
    public TMP_Text textSpeed;
    public TMP_Text textTime;
    public Distance distanceScript;

    public float playerSpeed;
    public string displaySpeed;
    public string displayTime;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.velocity.magnitude <= 0)
        {
            playerSpeed = 0;
        } else {
            playerSpeed = agent.speed;
        }

        displaySpeed = playerSpeed.ToString("f1");
        textSpeed.text = "[D/T]Speed: " + displaySpeed + " m/s";

        time = distanceScript.totalDistance / 8;
        time = Mathf.Round(time * 10.0f) * 0.1f;
        displayTime = time.ToString("F1");
        textTime.text = "[D/S]Time: " + displayTime + " s";
    }


}
