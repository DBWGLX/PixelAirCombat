using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   [SerializeField] private GameObject collisionEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;



        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {

            health.TakeDamage(1);
        }

        Explode();
    }

    public void Explode()
    {


        // 播放爆炸特效
        if (collisionEffect != null)
        {
            Instantiate(
                collisionEffect,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);


    }
}
