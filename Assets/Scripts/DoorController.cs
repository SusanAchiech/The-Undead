using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openDistance = 1.0f; // Adjust this distance based on your needs.
    private bool isOpen = false;

    private void Update()
    {
        // Find the player GameObject (you can modify this based on your player setup).
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the distance between the door and the player.
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (!isOpen && distanceToPlayer < openDistance)
            {
                // Open the door when the player is close enough.
                OpenDoor();
            }
            else
            {
                Debug.Log("Door not open");
            }
        }
    }

    void OpenDoor()
    {
        // Implement your door-opening logic here.
        // For example, you can play an animation or move the door.
        isOpen = true;
        Debug.Log("Door is open!");
    }
}
