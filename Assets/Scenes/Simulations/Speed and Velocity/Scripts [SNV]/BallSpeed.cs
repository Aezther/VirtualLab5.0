using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallSpeed : MonoBehaviour
{
    public TMP_Text followSpeed; // the ui that follows that ball displaying it's speed
    private Rigidbody rb; // references tha ball's rigid body
    public TMP_InputField distanceCheck; // checks if the InputField for Distance is empty
    public TMP_InputField timeCheck; // checks if the InputField for Time is empty
    public Button go; // go! disabler
    public TMP_Text BallES; // Displays the end speed once the ball stops rolling
    public float distance; // in meters
    public float time; // in seconds
    public bool test = false; //physics stopper

    
   
    void Start() //  Start is called before the first frame update
    {
        BallES.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void goMove() // the fuction executed once the Go! button is pressed
    {

        if (string.IsNullOrEmpty(distanceCheck.text) || string.IsNullOrEmpty(timeCheck.text)) // checks if the Distance and Time input is empty
        {
            test = false; // if the check returns true for either one, this is set to false, nothing will happen when the button is pressed
        } else
        {
            test = true; // if both input is not empty, the physics will then be released from pause
            go.gameObject.SetActive(false); // hides the Go! button once the ball is rolling
        }

    }

    void FixedUpdate() 
    {
        if (test == true) // a check to see if the physics is paused or not, if true, the physics will then play and the ball will start rolling
        {
            Vector3 speed = new Vector3(distance / time, 0f, 0f); // a vector that assigns the speed(distance/time) as a value to the x axis
            rb = GetComponent<Rigidbody>(); // references the rigidbody (ball)
            rb.velocity = speed; // assigns the vector as the speed of the rigidbody(ball)
            followSpeed.text = (rb.velocity.magnitude).ToString("00.00") + (" m/s"); // this is the text that follows the ball displaying it's speed

        } if (test == false) // opposite of the first if, sets the ball's speed to zero.
        {
            rb = GetComponent<Rigidbody>(); // references the rigidbody (ball)
            GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the speed to 0
            followSpeed.text = (rb.velocity.magnitude).ToString("00.00") + (" m/s"); // this is the text that follows the ball displaying it's speed

        }


    }

    public void getDistance(string s) // grabs the input from the distance inputfield
    {
        distance = float.Parse(s); // parses the string from the inputfield to float
    }

    public void getTime(string s) // grabs the input from the time inputfield
    {
        time = float.Parse(s); // parses the string from the inputfield to float
    }


    public void OnCollisionEnter(Collision stopText) // assined to the black wall at the end of the track, detects if the ball collided to it
    {
        if (stopText.collider.tag == "Stopper") // checks if the ball collided with the wall(the wall is tagged as "stopper")
        {
            Debug.Log("I have hit the stopper"); // prints the message to the console
            BallES.gameObject.SetActive(true); // enables the text that displays the formula and speed at the end of the track
            BallES.text = (distance)+(" meters")+(" / ")+(time)+(" seconds = ")+(distance/time).ToString("00.00") + (" m/s"); // the message displayed from the enabled text
            test = false; // stops the game physics
        }
    }


}
