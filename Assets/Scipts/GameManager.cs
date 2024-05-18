using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button backToMenuButton;
    public bool isOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    public void UpdateScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void UpdateLives()
    {
        if (!isOver)
        {
            lives--;
            livesText.text = "Lives: " + lives;

            if (lives <= 0)
                GameOver();
        }
    }

    public void GameOver()
    {
        isOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        backToMenuButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart the same screen
    }

}
