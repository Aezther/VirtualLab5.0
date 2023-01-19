using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void restartGame() // function executed once the restart button is pressed
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads the current scene, therefore restarting the game
    }
}
