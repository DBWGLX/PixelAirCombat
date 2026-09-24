using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int CurrentHealth => currentHealth;
    private int currentHealth;

    //死亡状态
    public GameOverManager gameOverManager;

    //无敌状态
    private bool isInvincible = false;
    // 玩家图片
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        HealthUI.Instance.UpdateHealth(currentHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;
        if (currentHealth <= 0)
            return;
        
        currentHealth -= damage;

        HealthUI.Instance.UpdateHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        // 受伤后进入 1 秒无敌
        StartInvincible(1f);
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

        HealthUI.Instance.UpdateHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Player Dead");
        gameOverManager.ShowGameOver();
    }

    //无敌
    public void StartInvincible(float duration)
    {
        StartCoroutine(InvincibleCoroutine(duration));
        InvincibleUI.Instance.Show(duration);
    }

    private IEnumerator InvincibleCoroutine(float duration)
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < duration)
        {
            // 隐藏
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);

            // 显示
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);

            timer += 0.2f;
        }

        isInvincible = false;
    }
}
