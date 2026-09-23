using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //移动
    private bool isDragging;
    private Vector3 touchOffset;

    //开火
    public GameObject bulletPrefab;

    //系统
    private Camera camera;

    void Awake(){
        camera = Camera.main;
    
        float bottom =
            Camera.main.transform.position.y
            - Camera.main.orthographicSize;

        transform.position = new Vector3(
            Camera.main.transform.position.x,
            bottom + 1f,
            transform.position.z
        );
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Touchscreen.current == null)
            return;

        var touch = Touchscreen.current.primaryTouch;

        // 手指刚按下
        if (touch.press.wasPressedThisFrame)
        {
            Vector2 screenPosition = touch.position.ReadValue();

            Vector3 worldPosition =
                Camera.main.ScreenToWorldPoint(screenPosition);

            worldPosition.z = transform.position.z;

            // 记录“手指位置”和“飞机位置”的偏移
            touchOffset = transform.position - worldPosition;

            isDragging = true;
        }

        // 手指持续按住
        if (isDragging && touch.press.isPressed)
        {
            Vector2 screenPosition = touch.position.ReadValue();

            Vector3 worldPosition =
                Camera.main.ScreenToWorldPoint(screenPosition);

            worldPosition.z = transform.position.z;

            // 保持原来的相对位置
            transform.position = worldPosition + touchOffset;

            ClampPosition();
        }

        // 手指松开
        if (touch.press.wasReleasedThisFrame)
        {
            isDragging = false;
        }

    }

    private void ClampPosition()//防飞机出去边界
    {
        // 摄像机在世界坐标中的半宽、半高
        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;

        // 飞机自身的一半大小
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float halfPlaneWidth = spriteRenderer.bounds.extents.x;
        float halfPlaneHeight = spriteRenderer.bounds.extents.y;

        Vector3 position = transform.position;

        // 允许飞机最多出去一半
        position.x = Mathf.Clamp(
            position.x,
            camera.transform.position.x - halfWidth - halfPlaneWidth,
            camera.transform.position.x + halfWidth + halfPlaneWidth
        );

        position.y = Mathf.Clamp(
            position.y,
            camera.transform.position.y - halfHeight - halfPlaneHeight,
            camera.transform.position.y + halfHeight + halfPlaneHeight
        );

        transform.position = position;
    }


    public void Fire()//开火
    {
        Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity
        );
    }
}
