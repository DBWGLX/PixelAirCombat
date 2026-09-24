using UnityEngine;

public class ItemBombExplosion : MonoBehaviour
{
    public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyCollision enemy =
                    other.GetComponent<EnemyCollision>();

            if (enemy != null)
            {
                enemy.Explode();
            }
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}