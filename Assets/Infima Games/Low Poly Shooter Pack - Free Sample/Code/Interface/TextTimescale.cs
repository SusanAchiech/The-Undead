using UnityEngine;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    public class TextTimescale : ElementText
    {
        private PlayerHealth playerHealth;
        private GameManager gameManager;

        void Start()
        {
            playerHealth = FindObjectOfType<PlayerHealth>(); // Find the PlayerHealth script
            gameManager = FindObjectOfType<GameManager>();
        }

        protected override void Tick()
        {
            if (playerHealth != null)
            {
                textMesh.text = "Player Health: " + playerHealth.PlayerCurrentHealth;
            }
        }

        // OnCollisionEnter is triggered when a collision happens
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Reduce player health by 10 when colliding with an enemy

                if (playerHealth.PlayerCurrentHealth <= 0)
                {
                    gameManager.PlayerDead = true;
                    textMesh.text = "Player Health: 0 (Player Dead)";
                }
                else
                {
                    textMesh.text = "Player Health: " + playerHealth.PlayerCurrentHealth;
                }
            }
        }
    }
}
