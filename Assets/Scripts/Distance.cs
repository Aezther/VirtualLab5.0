using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Distance : MonoBehaviour
{
private Vector3 lastPosition ;
//  private float totalDistance ;
 public TMP_Text textTotalDistance;
 public Transform player;
 public Transform baseOrigin;

 public Vector3 originalPos;
 public float distance;
 public float totalDistance;

 
 private void Start()
 {
     originalPos = player.transform.position;

    //  Debug.Log("Original Position: " + originalPos);
 }
 
 private void Update()
 {

    distance +=(transform.position - originalPos).magnitude;
    originalPos = transform.position;
    totalDistance = distance;
    totalDistance = Mathf.Round(totalDistance * 10.0f) * 0.1f;
    string displayDistance = totalDistance.ToString("F1");

    textTotalDistance.text = "Distance: " + displayDistance + " m";

    // Debug.Log("Update Position: " + originalPos);

     
 }
 

}
