using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public float shieldDuration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.StartInvincible(shieldDuration);
            Destroy(gameObject);
        }
    }
}