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
    public AudioClip attackSound;
    public AudioClip angrySound;
    private AudioSource audioSource;

    public float attackDistance = 2.0f;
    public float angryDistance = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        spawning = GetComponent<EnemySpawning>();
        Debug.Log("Finding player in the scene");
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            follow = playerObject.GetComponent<Transform>();
            StartCoroutine(WaitAndStartChasing(0.1f));
        }
        else
        {
            Debug.LogError("Player object not found with the 'Player' tag.");
        }

        audioSource = GetComponent<AudioSource>(); // Initialize the audioSource

        // You can play the attack sound here since it only needs to be played once
        PlayAttackSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            agent.SetDestination(follow.position);

            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(follow.position, transform.position);

            if (distanceToPlayer < attackDistance && !audioSource.isPlaying)
            {
                PlayAttackSound();
            }
            else if (distanceToPlayer > angryDistance && !audioSource.isPlaying)
            {
                PlayAngrySound();
            }
        }
    }

    void PlayAttackSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }

    void PlayAngrySound()
    {
        if (angrySound != null)
        {
            audioSource.PlayOneShot(angrySound);
        }
    }

    IEnumerator WaitAndStartChasing(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isChasing = true;
    }
}
