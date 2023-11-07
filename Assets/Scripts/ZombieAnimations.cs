using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
     Animator animator;
    public GameObject Zombie1;
    public Transform player;
    


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

 

    // Update is called once per frame
    void Update()
    {
        // You can add any relevant game logic here.

      
        
    }
}
