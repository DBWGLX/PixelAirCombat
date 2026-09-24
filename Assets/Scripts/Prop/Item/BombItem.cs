using UnityEngine;

public class BombItem : MonoBehaviour
{
    public GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        Destroy(gameObject);
    }


}