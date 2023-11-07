using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Player;
    public GameObject[] m_Enemy;

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

   // public Text MessageText;
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
        m_GameState  = GameState.Start;
    }
    // Start is called before the first frame update
    void Start()
    {

        // Deactivate player and enemy
        /*for (int i = 0; i < m_Player.Length; i++)
        {
            m_Player[i].SetActive(false);
        }*/

        /*for (int i = 0; i < m_Enemy.Length; i++)
        {
            m_Enemy[i].SetActive(false);
        }*/

        // m_Enemy.gameObject.SetActive(false);
        // m_Player.gameObject.SetActive(false);
        HighScoresButton.gameObject.SetActive(false);
        NewGameButton.gameObject.SetActive(false);
        //MessageText.text = "Start";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
