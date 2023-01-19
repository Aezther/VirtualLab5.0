using UnityEngine;
using TMPro;
using System;

public class SpeedIndicator : MonoBehaviour
{
    Vector3 lasPos, speed;
    public TMP_Text speedIndi;
    public float time;
    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        lasPos = transform.position;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = (transform.position - lasPos) / Time.deltaTime; ;
        speed = (transform.position - lasPos) / Time.deltaTime;
        lasPos = transform.position;
        speedIndi.text = speed.magnitude.ToString("F1") + " m/s";


        if (speed.magnitude>1)
        {
            time = time + Time.deltaTime;
            TimeSpan timeee = TimeSpan.FromSeconds(time);
            timer.text = time.ToString("F1")+" s";
            
        }

    }
}
