using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    //float randomValue = UnityEngine.Random;

    public Transform follow;

    private UnityEngine.AI.NavMeshAgent agent;

    public GameObject Zombie1;

    public int xPos;
    public int zPos;
    public int ZombieCount;

    //float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //StartCaroutine(ZombieDrop());
       // Vector3 spawnPosition = new Vector3(0, 0, 0); 
        //Quaternion spawnRotation = Quaternion.identity; 
    }
     

        IEnumerator ZombieDrop()
        {
            while(ZombieCount < 10) 
        {
            //xPos = Random.range(1, 50);
            //zPos = Random.range(1, 31);
            Instantiate(Zombie1, new Vector3 (xPos, 43, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            ZombieCount += 1;
        }
        }


    
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(follow.position);
        /* if (timer <= 0)
         {
             timer = 1;
         }*/

        /*timer -= Time.deltaTime;*/

        //timer -= Time.DeltaTime is similar to writing timer = timer - Time.deltaTime
    }
}
