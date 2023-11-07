using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    

    public Transform follow;

    private UnityEngine.AI.NavMeshAgent agent;
    private bool isChasing = false;

    private EnemySpawning spawning;

    
   

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(WaitAndStartChasing(1f));
        spawning = GetComponent<EnemySpawning>();
        follow = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }
     

        
    
    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
        agent.SetDestination(follow.position);
        }
        
    }

    IEnumerator WaitAndStartChasing(float waitTime)
    {
        //wait for a specified amount of time
        yield return new WaitForSeconds(waitTime);

        //start chasing
        isChasing = true;
    }
}
