using System;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    NavMeshAgent agent;
    int moveCount = 0;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (moveCount<10)
        //{

            if (Input.GetMouseButtonDown(1))
            {
                moveCount++;
               
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    agent.SetDestination(hit.point);
                }
            }
        //} else
        //{
        //    //Debug.Log("No more movement left!")

        //}


    }

  




}
