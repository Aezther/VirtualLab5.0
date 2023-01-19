using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
   public void SwitchtoDistanceFarm()
    {
        SceneManager.LoadScene(3);
    }

   public void SwitchtoDisplacementTrack()
    {
        SceneManager.LoadScene(4);
    }

    public void SwitchtoQuiz()
    {
        SceneManager.LoadScene(5);
    }

    public void EXitSim()
    {
        Application.Quit();
    }

}
