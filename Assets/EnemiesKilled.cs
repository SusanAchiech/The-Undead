using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour
{
    private GameManager gamemanager;
    public Text enemiesKilledText;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gamemanager.totalEnemiesKilled <= 20)
        {
            enemiesKilledText.text = "Enemies Killed: " + gamemanager.totalEnemiesKilled + " / 20";
        }
        else
        {
            enemiesKilledText.text = "All enemies killed!";
        }
    }
}
