using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog_AI : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Transform tenemy;

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FieldOfView.canSeePlayer == true)
        {
            enemy.SetDestination(player.position);
        }
        else
        {

        }
    }
}
