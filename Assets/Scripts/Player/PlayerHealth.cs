using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int CurrentHealth => currentHealth;
    private int currentHealth;

    public GameOverManager gameOverManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        HealthUI.Instance.UpdateHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;
        
        currentHealth -= damage;

        HealthUI.Instance.UpdateHealth(currentHealth);
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Dead");
        gameOverManager.ShowGameOver();
    }
}
