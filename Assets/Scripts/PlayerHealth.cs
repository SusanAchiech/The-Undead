using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    bool PlayerDead;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDead = false;
        PlayerMaxHealth = PlayerCurrentHealth;
        animator = GetComponent<Animator>();
    }

    private void PlayerDestroy()
    {
        if (!PlayerDead)
        {

            PlayerDead = true;
            Debug.Log("Player dead");
            gameObject.SetActive(false);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            PlayerCurrentHealth -= 2;
            Debug.Log("Player health reduced by 2");

            if (PlayerCurrentHealth <= 0)
            {
                PlayerDestroy();
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
