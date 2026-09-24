using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text scoreText;

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        scoreText.text = "Final SCORE:\n\n" + ScoreManager.Instance.Score;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
