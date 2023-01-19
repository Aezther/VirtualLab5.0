using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockadeCollision : MonoBehaviour
{
    private Rigidbody rb;
    public Transform user;
    public Button right;
    public Canvas tooltip;

    // Start is called before the first frame update
    void Start()
    {
        user.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        tooltip.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void releaseBall()
    {
        user.gameObject.SetActive(true);
    }

    public void OnCollisionEnter(Collision stopText) // assined to the black wall at the end of the track, detects if the ball collided to it
    {
        if (stopText.collider.tag == "Stopper") // checks if the ball collided with the wall(the wall is tagged as "stopper")
        {
            Debug.Log("I have hit the stopper"); // prints the message to the console
            right.gameObject.SetActive(true);
            tooltip.gameObject.SetActive(true);
            
        }
    }


}
