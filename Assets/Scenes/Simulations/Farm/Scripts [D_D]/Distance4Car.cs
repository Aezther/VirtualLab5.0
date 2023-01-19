using UnityEngine;
using TMPro;
public class Distance4Car : MonoBehaviour
{
    public TMP_Text ObjectDistance;
    Vector3 lastPosition;
    public float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(lastPosition, transform.position);
        distanceTravelled += distance;
        lastPosition = transform.position;

        if (distanceTravelled < 0.1)
        {
            ObjectDistance.text = "total distance travelled: 0 m";
        }
        else
        {
            ObjectDistance.text = "total distance travelled: " + (distanceTravelled-8.9).ToString("F0") + " m";
        }

    }


}
