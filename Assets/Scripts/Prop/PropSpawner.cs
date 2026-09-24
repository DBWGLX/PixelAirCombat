using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject[] propPrefabs;
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
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

        // 随机选择一种
        GameObject propPrefab =
            propPrefabs[Random.Range(0, propPrefabs.Length)];

        Instantiate(
            propPrefab,
            spawnPosition,
            Quaternion.identity
        );

        //再次生成
        // 随机等待 0.5 ~ 3 秒后再次生成
        float nextSpawnTime =
            Random.Range(minSpawnInterval, maxSpawnInterval);

        Invoke(nameof(SpawnEnemy), nextSpawnTime);
    }

}


