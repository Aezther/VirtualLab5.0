using UnityEngine;

public class TooltipPanel : MonoBehaviour
{
    private int counter = 0;
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
            counter++;
            Panel.gameObject.SetActive(true);
        } else
        {
            counter = 0;
            Panel.gameObject.SetActive(false);
        }
    }
}
