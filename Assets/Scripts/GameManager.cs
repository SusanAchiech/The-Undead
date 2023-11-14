using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Player;
    public List<GameObject>m_Enemy = new List<GameObject>();
    public bool zombieDead;
    public bool PlayerDead;
    public int totalEnemiesKilled = 0;
    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    public GameObject m_P_LPSP_UI_Canvas;
    public GameObject m_HighScorePanel;
    public Text m_HighScoresText;
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

    private HighScores highScores;

    public void Awake()
    {
        m_GameState = GameState.Start;
        highScores = GetComponent<HighScores>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate enemy
        for (int i = 0; i < m_Enemy.Count; i++)
        {
            m_Enemy[i].SetActive(false);
        }
        for (int i = 0; i < m_Player.Length; i++)
        {
            m_Player[i].SetActive(true);
        }
        m_P_LPSP_UI_Canvas.gameObject.SetActive(false);
        m_HighScorePanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
                    // Activate enemy
                    for (int i = 0; i < m_Enemy.Count; i++)
                    {
                        m_Enemy[i].SetActive(true);
                    }
                    m_P_LPSP_UI_Canvas.gameObject.SetActive(true);
                }
                break;
            case GameState.Playing:
                bool isGameOver = false;

                if ( PlayerDead)
                {
                    isGameOver = true;
                }

                if (totalEnemiesKilled >= 20)
                {
                    MessageText.text = "You Win!";
                    isGameOver = true;
                    // Deactivating player and enemy
                    SetPlayerAndEnemyActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    NewGameButton.gameObject.SetActive(true);
                    HighScoresButton.gameObject.SetActive(true);
                }

                if (isGameOver)
                {
                    m_GameState = GameState.GameOver;

                    if (PlayerDead)
                    {
                        MessageText.text = "Game Over";
                        m_P_LPSP_UI_Canvas.gameObject.SetActive(false);
                        SetPlayerAndEnemyActive(false);
                        Cursor.visible = true;
                        NewGameButton.gameObject.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        HighScoresButton.gameObject.SetActive(true);
                    }
                }
                break;
            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    m_GameState = GameState.Playing;
                    MessageText.text = "You Lose, Game Over!";
                    Debug.Log("Game over");
                    SetPlayerAndEnemyActive(false);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    HighScoresButton.gameObject.SetActive(true);
                    NewGameButton.gameObject.SetActive(true);
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
        Debug.Log("The button is functioning");
       // m_P_LPSP_UI_Canvas.gameObject.SetActive(true);
        m_HighScorePanel.SetActive(false);
        m_GameState = GameState.Playing;
        MessageText.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        NewGameButton.gameObject.SetActive(false);
        HighScoresButton.gameObject.SetActive(false);
        SetPlayerAndEnemyActive(true); // Activate player and enemy
        SceneManager.LoadScene(0);
    }

    private void SetPlayerAndEnemyActive(bool isActive)
    {
        Debug.Log("Both player and enemy are active");
        foreach (var player in m_Player)
        {
            player.SetActive(isActive);
        }

        foreach (var enemy in m_Enemy)
        {
            enemy.SetActive(isActive);
        }
    }

    public void OnHighScores()
    {
        MessageText.text = "";
        //m_P_LPSP_UI_Canvas.gameObject.SetActive(false);
        HighScoresButton.gameObject.SetActive(false);
        m_HighScorePanel.SetActive(true);
        string text = "";
        for (int i = 0; i < highScores.scores.Length; i++) // Access scores through the instance
        {
            int seconds = highScores.scores[i];
            text += string.Format("{0:D2}:{1:D2}\n", (seconds / 60), (seconds % 60));
        }
        m_HighScoresText.text = text;

    }
}
