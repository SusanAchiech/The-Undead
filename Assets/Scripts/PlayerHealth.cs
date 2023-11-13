
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;
    public bool PlayerDead;
    private GameManager gamemanager;

    void Start()
    {
        PlayerDead = false;
        PlayerCurrentHealth = PlayerMaxHealth;
        gamemanager = FindObjectOfType<GameManager>();
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

    public void TakeDamage(int amount)
    {
        PlayerCurrentHealth -= amount;
        if (PlayerCurrentHealth <= 0)
        {
            PlayerDestroy();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // Reduce health by 10 when colliding with an enemy.
        }
    }
}
