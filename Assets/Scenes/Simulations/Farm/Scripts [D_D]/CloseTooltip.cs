using UnityEngine;

public class CloseTooltip : MonoBehaviour
{
    private int counter = 1;
    public Canvas Panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void hideTooltip()
    {
        if (counter==0)
        {
            Panel.gameObject.SetActive(true);
        } else
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
