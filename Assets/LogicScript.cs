using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text maxScore;
    public GameObject gameOverScreen;
    private const string HighScoreKey = "MaxFlappyScore";

    [ContextMenu("Increase Score")]

    void Start()
    {
        int savedScore=PlayerPrefs.GetInt(HighScoreKey,0);
        if (maxScore != null)
        {
            maxScore.text=savedScore.ToString();
        }
    }
    public void AddScore(int scoreToAdd)
    {
        
        playerScore+=scoreToAdd;
        scoreText.text = playerScore.ToString();
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (playerScore > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, playerScore);
            PlayerPrefs.Save();
            Debug.Log("New HIgh Score Saved: " + playerScore);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
