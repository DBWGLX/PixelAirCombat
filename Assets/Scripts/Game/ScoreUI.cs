using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //临时方案
    {
        scoreText.text =
            "Score: " + ScoreManager.Instance.Score;
    }
}
