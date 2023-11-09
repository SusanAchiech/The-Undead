using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI; // Make sure to include the UnityEngine.AI namespace for NavMeshAgent.

public class EnemySpawning : MonoBehaviour
{
    public GameObject Zombie1;
    public Transform player; // Reference to the player's transform.
    public int ZombieCount;
    public int TotalZombies;
    private GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = (GameManager)FindObjectOfType(typeof(GameManager));
        StartCoroutine(ZombieDrop());
    }

    public IEnumerator ZombieDrop()
    {
        ZombieCount = 0;
        while (ZombieCount < TotalZombies)
        {
            ZombieCount += 1;
            Vector3 randomPosition = GetRandomNavMeshPosition();
            GameObject newZombie = Instantiate(Zombie1, randomPosition, Quaternion.identity);
            gamemanager.m_Enemy.Add(newZombie);

            // Set the destination of the NavMeshAgent to the player's position.
            NavMeshAgent zombieAgent = newZombie.GetComponent<NavMeshAgent>();
            if (zombieAgent != null && zombieAgent.isActiveAndEnabled)
            {
                zombieAgent.SetDestination(player.position);
                Debug.Log("Enemies Generated");
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    Vector3 GetRandomNavMeshPosition()
    {
        NavMeshHit hit;
        Vector3 randomPosition;

        // Generate a random point within the NavMesh bounds.
        do
        {
            randomPosition = new Vector3(UnityEngine.Random.Range(10, 5), UnityEngine.Random.Range( 0, 0.9f), UnityEngine.Random.Range(6, 10));
        } while (!NavMesh.SamplePosition(randomPosition, out hit, 1.0f, NavMesh.AllAreas));

        return hit.position;
    }

    public void OnDeath()
    {
        Vector3 randomPosition = GetRandomNavMeshPosition();
        GameObject newZombie = Instantiate(Zombie1, randomPosition, Quaternion.identity);

        // Set the destination of the NavMeshAgent to the player's position.
        NavMeshAgent zombieAgent = newZombie.GetComponent<NavMeshAgent>();
        if (zombieAgent != null)
        {
            zombieAgent.SetDestination(player.position);
        }

        Debug.Log("New Enemy Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any relevant game logic here.
    }
}
