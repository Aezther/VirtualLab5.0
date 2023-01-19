using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void learnMicroParts()
    {
        SceneManager.LoadScene(2);
    }

    public void exploreFocus()
    {
        SceneManager.LoadScene(1);
    }

}
