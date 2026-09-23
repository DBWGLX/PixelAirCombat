using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Camera camera = Camera.main;

        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;

        // 左右各留 10% 的安全区域
        float xRange = halfWidth * 0.9f;

        // 从屏幕顶部稍微外面的位置生成
        float spawnY =
            camera.transform.position.y + halfHeight + 1f;

        float x = Random.Range(-xRange, xRange);

        Vector3 spawnPosition = new Vector3(
            camera.transform.position.x + x,
            spawnY,
            0f
        );

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

}


