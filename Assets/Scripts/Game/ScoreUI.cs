using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
