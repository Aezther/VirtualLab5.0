using UnityEngine;
using TMPro;

public class FarmDisplacement : MonoBehaviour
{

    public GameObject Anchor;
    public GameObject Object;
    public TMP_Text ObjectDistance;
    public float displacementValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {



        /// Displacement Part
        displacementValue = Vector3.Distance(Anchor.transform.position, Object.transform.position);
        if (displacementValue <= 0.1)
        {
            ObjectDistance.text = "displacement: 0 m";
        }else
        {
             ObjectDistance.text = "displacement: " + displacementValue.ToString("F0") + " m";
        }

        /// Displacement Part

    }
}
