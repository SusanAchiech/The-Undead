using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Player;
    public GameObject[] m_Enemy;
    public bool zombieDead;
    public bool PlayerDead;

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    public Text MessageText;
    public Button NewGameButton;
    public Button HighScoresButton;

    private GameState m_GameState;
    public GameState state
    {
        get
        {
            return m_GameState;
        }
    }

    public void Awake()
    {
        m_GameState = GameState.Start;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate enemy
        for (int i = 0; i < m_Enemy.Length; i++)
        {
            m_Enemy[i].SetActive(false);
        }
        for (int i = 0; i < m_Player.Length; i++)
        {
            m_Player[i].SetActive(true);
        }
        HighScoresButton.gameObject.SetActive(false);
        NewGameButton.gameObject.SetActive(false);
        MessageText.text = "Press Enter to Start";
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GameState)
        {
            case GameState.Start:
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    MessageText.text = "";
                    m_GameState = GameState.Playing;
                    // Activate player and enemy
                    for (int i = 0; i < m_Enemy.Length; i++)
                    {
                        m_Enemy[i].SetActive(true);

                    }
                }
                break;
            case GameState.Playing:
                bool isGameOver = false;

                if (zombieDead || PlayerDead)
                {
                    isGameOver = true;
                }

                if (isGameOver)
                {
                    m_GameState = GameState.GameOver;
                    NewGameButton.gameObject.SetActive(true);
                    HighScoresButton.gameObject.SetActive(true);

                    if (PlayerDead)
                    {
                        MessageText.text = "Game Over";
                        SetPlayerAndEnemyActive(false); // Deactivate player and enemy
                    }
                    else
                    {
                        MessageText.text = "You Win!";
                        // Handle the win condition
                    }
                }
                break;
            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    m_GameState = GameState.Playing;
                    MessageText.text = "You Lose, Game Over!";
                    SetPlayerAndEnemyActive(false); // Activate player and enemy
                }
                break;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnNewGame()
    {
        m_GameState = GameState.Playing;
        MessageText.gameObject.SetActive(false);
        NewGameButton.gameObject.SetActive(false);
        HighScoresButton.gameObject.SetActive(false);
        SetPlayerAndEnemyActive(true); // Activate player and enemy
    }

    private void SetPlayerAndEnemyActive(bool isActive)
    {
        foreach (var player in m_Player)
        {
            player.SetActive(isActive);
        }

        foreach (var enemy in m_Enemy)
        {
            enemy.SetActive(isActive);
        }
    }
}
