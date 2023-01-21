using UnityEngine;

public class TrackManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySim()
    {
        Time.timeScale = 1;
    }
}
