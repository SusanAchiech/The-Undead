using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    public bool PlayerDead;
    Animator animator;
    private GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDead = false;
        PlayerCurrentHealth = PlayerMaxHealth;
        animator = GetComponent<Animator>();
        gamemanager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    private void PlayerDestroy()
    {
        if (!PlayerDead)
        {

            PlayerDead = true;
            
            Debug.Log("Player dead");
            gamemanager.PlayerDead = true;
            gameObject.SetActive(false);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            {

            PlayerCurrentHealth -= 10;
            Debug.Log("Player health reduced by 10");
            Debug.Log("Player current health is " + PlayerCurrentHealth);

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
