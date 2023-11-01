using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    bool zombieDead;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        zombieDead = false;
        maxHealth = currentHealth;
        animator = GetComponent<Animator>();
    }

    private void TargetDestroy ()
    { 
        if (!zombieDead)
        {

        zombieDead = true;
        Debug.Log("Zombie dead");
        gameObject.SetActive(false);
        animator.SetTrigger("Die");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Assuming "Bullet" is the tag of your bullet object.
            currentHealth -= 5; // Decrease the zombie's health by 5.

            if (currentHealth <= 0)
            {
                TargetDestroy();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
