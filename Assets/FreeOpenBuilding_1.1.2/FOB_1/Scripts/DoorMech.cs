using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMech : MonoBehaviour 
{

    public Vector3 OpenRotation, CloseRotation;
    public float rotSpeed = 1f;
    public bool doorBool;

    private bool playerNearby = false;

    void Start()
    {
        doorBool = false;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerNearby = true;           
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerNearby = false;

            if (doorBool)
            {
                Invoke("CloseDoor", 3f); 
            }
        }
    }

    private void CloseDoor()
    {
        doorBool = false;
        Debug.Log("Player passed, door closed");

    }


   

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!doorBool)
            {
                doorBool = true;
                Debug.Log("Door open");
            }
            else
            {
                doorBool = false;
                Debug.Log("Door closed");
            }
        }

        if (doorBool)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(OpenRotation), rotSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CloseRotation), rotSpeed * Time.deltaTime);
    }

}

