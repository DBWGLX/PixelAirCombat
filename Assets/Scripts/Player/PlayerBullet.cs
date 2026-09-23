using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //子弹属性
    public float speed = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        transform.position +=
            Vector3.up * speed * Time.deltaTime;

        CheckOutOfScreen();
    }

    void CheckOutOfScreen()
    {
        Camera camera = Camera.main;

        float top =
            camera.transform.position.y + camera.orthographicSize;

        if (transform.position.y > top + 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
            //获得 敌机 脚本组件
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Explode();
                ScoreManager.Instance.AddScore(10);
            }
        }
    }
}
