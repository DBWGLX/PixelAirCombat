using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class InvincibleUI : MonoBehaviour
{
    public static InvincibleUI Instance;

    public GameObject panel;
    public Image timerImage;

    public Sprite[] numberSprites;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show(float duration)
    {
        panel.SetActive(true);
        
        StartCoroutine(Countdown(duration));
    }

    private IEnumerator Countdown(float duration) // `IEnumerator` 是 **C# 迭代器接口（System.Collections.IEnumerator）**
    {
        int seconds = Mathf.CeilToInt(duration);

        while (seconds > 0)
        {
            timerImage.sprite = numberSprites[seconds];

            yield return new WaitForSeconds(1f);

            seconds--;
        }

        timerImage.sprite = numberSprites[0];

        yield return new WaitForSeconds(0.5f);

        panel.SetActive(false);
    }
}