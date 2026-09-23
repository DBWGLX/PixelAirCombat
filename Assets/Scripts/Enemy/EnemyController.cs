using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 敌机控制
    public float speed = 2f;

    //碰撞效果
    [SerializeField] private GameObject collisionEffect;//让**私有 private 字段，可以在 Unity Inspector 面板显示、拖拽赋值**。
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=
            Vector3.down * speed * Time.deltaTime;

        CheckOutOfScreen();
    }

    void CheckOutOfScreen()//销毁
    {
        Camera camera = Camera.main;

        float bottom =
            camera.transform.position.y - camera.orthographicSize;

        if (transform.position.y < bottom - 1f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)//碰撞逻辑
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health =
                other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(1);
            }

 
            Explode();
        }
    }

    public void Explode()
    {
        // 播放爆炸特效
        Instantiate(collisionEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

