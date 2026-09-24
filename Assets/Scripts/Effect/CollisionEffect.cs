using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }


    private void Update()
    {
        if (!particleSystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
