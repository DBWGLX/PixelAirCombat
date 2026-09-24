using UnityEngine;

public class PropController : MonoBehaviour
{
    // 敌机控制
    public float speed = 1.5f;
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

