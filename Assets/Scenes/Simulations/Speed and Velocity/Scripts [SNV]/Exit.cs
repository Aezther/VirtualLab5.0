using UnityEngine;

public class Exit : MonoBehaviour
{

    void Awake()
    {
        
    }

  public void exitGame() // executed once the exit button is pressed
    {
        Application.Quit(); // closes the game
    }
}
