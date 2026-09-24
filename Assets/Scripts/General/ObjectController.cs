using UnityEngine;

public class ObjectController : MonoBehaviour
{

    public float scale = 2f;
    //放大 scale
    private void Awake()
    {
        transform.localScale *= scale;
    }
}
