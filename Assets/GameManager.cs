using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float score;
    private bool isGameOver;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        Time.timeScale = 1f;
        score = 0f;
        isGameOver = false;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        UpdateScoreText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            UpdateScoreText();
        }

        if (isGameOver && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER\nPress SPACE to Restart";
            gameOverText.gameObject.SetActive(true);
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }
}