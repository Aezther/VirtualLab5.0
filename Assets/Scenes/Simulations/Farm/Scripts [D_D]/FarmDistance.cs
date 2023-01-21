using UnityEngine;
using TMPro;
public class FarmDistance : MonoBehaviour
{
    public TMP_Text ObjectDistance;
    Vector3 lastPosition;
    public float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(lastPosition, transform.position);
        distanceTravelled += distance;
        lastPosition = transform.position;

        if (distanceTravelled < 1)
        {
            ObjectDistance.text = "total distance travelled: 0 m";
        } else
        {
            ObjectDistance.text = "total distance travelled: " + distanceTravelled.ToString("F0") + " m";
        }

       

    }
}
