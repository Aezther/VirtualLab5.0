using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision stopText) // assined to the black wall at the end of the track, detects if the ball collided to it
    {
        if (stopText.collider.tag == "Player") // checks if the ball collided with the wall(the wall is tagged as "stopper")
        {
            Debug.Log("I have hit the player"); // prints the message to the console
            

        }
    }
}
