using UnityEngine;

public class RedPlane1Attack : MonoBehaviour
{
    [Header("子弹")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("攻击")]
    public float minDelay = 0f;
    public float maxDelay = 2f;

    private Transform player;

    private void Start()
    {
        // 找到玩家
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // 50% 概率攻击
        if (Random.value < 0.5f)
        {
            float delay = Random.Range(minDelay, maxDelay);
            Invoke(nameof(Fire), delay);
        }

        //
        if (Random.value < 0.2f)
        {
            float delay = Random.Range(minDelay, maxDelay);
            Invoke(nameof(Fire), delay);
        }

        if (Random.value < 0.01f)
        {
            float delay = Random.Range(minDelay, maxDelay);
            Invoke(nameof(Fire), delay);
        }
    }

    private void Fire()
    {
        if (player == null || bulletPrefab == null)
            return;

        // 从发射点创建子弹
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        // 子弹朝向玩家
        Vector2 direction = (player.position - firePoint.position).normalized;

        // 增加 -10° ~ 10° 的随机偏移
        float randomAngle = Random.Range(-10f, 10f);
        direction = Quaternion.Euler(0, 0, randomAngle) * direction;

        // 把方向传给子弹
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }

}
