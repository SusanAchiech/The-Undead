using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class HighScores : MonoBehaviour
{
    // Path to the high scores file
    private string highScoresFilePath = "Assets/highscores.txt";

    // Array to store high scores
    public int[] scores;

    private void Start()
    {
        // Check if the high scores file exists
        if (File.Exists(highScoresFilePath))
        {
            // If the file exists, load the scores from it
            Debug.Log("The file highscores.txt was found. Scores will be loaded");
            LoadScores();
        }
        else
        {
            // If the file doesn't exist, initialize the scores array
            scores = new int[10];
            Debug.LogWarning("The file highscores.txt does not exist. No scores will be loaded.");
        }
    }

    // Load high scores from the file
    private void LoadScores()
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(highScoresFilePath);

            // Initialize the scores array with the loaded data
            scores = new int[lines.Length + 1];

            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out int score))
                {
                    scores[i] = score;
                }
                else
                {
                    Debug.LogError("Error parsing score from highscores.txt");
                }
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Error loading high scores: " + e.Message);
        }
    }

    // Update a score and then save high scores to the file
    public void UpdateAndSaveScore(int index, int newScore)
    {
        if (index >= 0 && index < scores.Length)
        {
            scores[index] = newScore;
            SaveScores();
        }
        else
        {
            Debug.LogError("Invalid index for updating score");
        }
    }

    // Save high scores to the file
    public void SaveScores()
    {
        try
        {
            // Convert the scores array to strings
            string[] scoreStrings = new string[scores.Length];

            for (int i = 0; i < scores.Length; i++)
            {
                scoreStrings[i] = scores[i].ToString();
            }

            // Write the strings to the file
            File.WriteAllLines(highScoresFilePath, scoreStrings);
            Debug.Log("High scores running");
        }
        catch (IOException e)
        {
            Debug.LogError("Error saving high scores: " + e.Message);
        }
    }
}