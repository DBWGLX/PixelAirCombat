using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    public ScoreUI scoreUI;
    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        Score += amount;

        scoreUI.UpdateScore(Score);
    }

}
