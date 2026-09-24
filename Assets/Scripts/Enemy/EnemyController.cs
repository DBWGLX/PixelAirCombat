using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 敌机控制
    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
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

}

