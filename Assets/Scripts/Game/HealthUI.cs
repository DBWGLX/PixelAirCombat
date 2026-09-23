using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance { get; private set; }

    public Image[] hearts; //每个桃心

    public Sprite heartRed; //红心属性
    public Sprite heartGray;
    // 存红心原始尺寸，切换灰心时用这个做参考
    private Vector2 heartOriginalSize;

    void Awake()
    {
        Instance = this;
        heartOriginalSize = hearts[0].rectTransform.sizeDelta;
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = heartRed;
            }
            else
            {
                hearts[i].sprite = heartGray;

                //调图片尺寸
                hearts[i].rectTransform.sizeDelta = heartOriginalSize * 0.7f;
            }
        }
    }
}